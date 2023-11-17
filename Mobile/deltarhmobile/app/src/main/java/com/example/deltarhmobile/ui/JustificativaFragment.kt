package com.example.deltarhmobile.ui

import android.annotation.SuppressLint
import android.app.Activity
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import android.widget.TextView
import androidx.activity.result.contract.ActivityResultContracts
import androidx.annotation.RequiresApi
import androidx.lifecycle.lifecycleScope
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.model.JustificativaModel
import com.example.deltarhmobile.retrofit.model.PontoModel
import kotlinx.coroutines.launch
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.text.SimpleDateFormat
import java.util.Date
import java.util.Locale
import java.util.Base64

@RequiresApi(Build.VERSION_CODES.O)
class JustificativaFragment : Fragment() {

    private var selectedFileBytes: ByteArray? = null
    private var documentString: String? = null

    private val pickFileLauncher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            result.data?.data?.let { uri ->
                val contentResolver = requireActivity().contentResolver
                val inputStream = contentResolver.openInputStream(uri)
                inputStream?.use { input ->
                    selectedFileBytes = input.readBytes()
                    documentString = Base64.getEncoder().encodeToString(selectedFileBytes)
                }
            }
        }
    }

     override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {

        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_justificativa, container, false)
    }

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val spinnerJustificativas = view.findViewById<Spinner>(R.id.spinner_tipo_justificativa)
        val textDescricao = view.findViewById<EditText>(R.id.textbox_descricao)
        val buttonDocument = view.findViewById<Button>(R.id.anexar_button)
        val registrarJustificativaButton = view.findViewById<Button>(R.id.registrar_justificativa_button)

        val dateText = view.findViewById<TextView>(R.id.text_data_justificativa)
        val timeText = view.findViewById<TextView>(R.id.text_hora_justificativa)
        val dataHoraAtual = Date()
        val formatoData = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
        val formatoHora = SimpleDateFormat("HH:mm", Locale.getDefault())
        dateText.text = formatoData.format(dataHoraAtual)
        timeText.text = formatoHora.format(dataHoraAtual)

        val backButton = view.findViewById<Button>(R.id.button_back_justificativa)
        backButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(MenuFragment(), false)
        }

        try {
            val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
            val callCarregarPonto: Call<PontoModel> = userAPI.carregarPonto()
            
            lifecycleScope.launch{
                callCarregarPonto.enqueue(object : Callback<PontoModel> {
                    override fun onResponse(
                        call: Call<PontoModel>,
                        response: Response<PontoModel>
                    ) {
                        val responseBodyIncial = response.body()
                        carregarJustificativa(responseBodyIncial, view)
                    }

                    override fun onFailure(call: Call<PontoModel>, t: Throwable) {
                        val responseBodyIncial = null
                        carregarJustificativa(responseBodyIncial, view)
                    }

                })
            }

            buttonDocument.setOnClickListener{
                startFileSelection()
            }

            registrarJustificativaButton.setOnClickListener{
                val justificativa = JustificativaModel(
                    spinnerJustificativas.selectedItem.toString(),
                    textDescricao.text.toString(),
                    documentString
                )

                registrarJustificativa(justificativa, view)
            }
        }catch (e : Exception){
            Log.d("Erro busca:", e.stackTraceToString())
        }
    }

    @SuppressLint("SetTextI18n")
    private fun carregarJustificativa(pontoModel: PontoModel?, view: View){
        val spinnerJustificativas = view.findViewById<Spinner>(R.id.spinner_tipo_justificativa)
        val textDescricao = view.findViewById<EditText>(R.id.textbox_descricao)
        val buttonDocument = view.findViewById<Button>(R.id.anexar_button)
        val registrarJustificativaButton = view.findViewById<Button>(R.id.registrar_justificativa_button)

        val tiposJustificativa = arrayListOf<String>("FALTA","ATESTADO","ATRASO","HORA_EXTRA","OUTROS")
        if (spinnerJustificativas != null) {
            val adapter = ArrayAdapter(requireContext(), android.R.layout.simple_spinner_item, tiposJustificativa)
            spinnerJustificativas.adapter = adapter
        }

        if(pontoModel?.tipoJustificativa != null){
            spinnerJustificativas.setSelection(tiposJustificativa.indexOf(pontoModel.tipoJustificativa))

            textDescricao.setText(pontoModel.descricao)

            if(pontoModel.documento != null){
                buttonDocument.text = "Documento anexado"
            }else{
                buttonDocument.text = "Sem anexo"
            }

            spinnerJustificativas.isEnabled = false
            textDescricao.isEnabled = false
            buttonDocument.isEnabled = false
            registrarJustificativaButton.isEnabled = false
        }
    }

    @SuppressLint("SetTextI18n")
    private fun registrarJustificativa(justificativa: JustificativaModel, view : View){

        val justificativaRegistradaText = view.findViewById<TextView>(R.id.justificativa_registrado_text)

        try {
            val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
            val callRegistrarJustificativa: Call<PontoModel> = userAPI.registrarJustificativa(justificativa)

            callRegistrarJustificativa.enqueue(object : Callback<PontoModel> {
                override fun onResponse(call: Call<PontoModel>, response: Response<PontoModel>) {
                    carregarJustificativa(response.body(), view)
                    justificativaRegistradaText.visibility = View.VISIBLE
                }
                override fun onFailure(call: Call<PontoModel>, t: Throwable) {
                    carregarJustificativa(null, view)
                    justificativaRegistradaText.text = "Erro ao registrar justificativa"
                    justificativaRegistradaText.visibility = View.VISIBLE
                }

            })
        }catch (e : Exception){
            Log.d("Erro busca:", e.stackTraceToString())
        }
    }

    private fun startFileSelection() {
        val intent = Intent(Intent.ACTION_OPEN_DOCUMENT).apply {
            addCategory(Intent.CATEGORY_OPENABLE)
            type = "*/*"  // Você pode especificar tipos MIME específicos aqui, se desejar
        }
        pickFileLauncher.launch(intent)
    }

    companion object
}