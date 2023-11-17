package com.example.deltarhmobile.ui

import android.annotation.SuppressLint
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.lifecycle.lifecycleScope
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.model.PontoModel
import com.example.deltarhmobile.retrofit.model.TipoPonto
import kotlinx.coroutines.launch
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.text.SimpleDateFormat
import java.util.Date
import java.util.Locale

class PontoFragment : Fragment() {

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
        return inflater.inflate(R.layout.fragment_ponto, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val dateText = view.findViewById<TextView>(R.id.text_data)
        val timeText = view.findViewById<TextView>(R.id.text_hora)
        val backButton = view.findViewById<Button>(R.id.button_back)
        val entradaButton = view.findViewById<Button>(R.id.entrada_button)
        val pausaButton = view.findViewById<Button>(R.id.pausa_button)
        val retornoButton = view.findViewById<Button>(R.id.retorno_button)
        val saidaButton = view.findViewById<Button>(R.id.saida_button)

        val dataHoraAtual = Date()
        val formatoData = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
        val formatoHora = SimpleDateFormat("HH:mm", Locale.getDefault())
        dateText.text = formatoData.format(dataHoraAtual)
        timeText.text = formatoHora.format(dataHoraAtual)

        val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
        val callCarregarPonto: Call<PontoModel> = userAPI.carregarPonto()

        lifecycleScope.launch{
            callCarregarPonto.enqueue(object : Callback<PontoModel> {
                override fun onResponse(call: Call<PontoModel>, response: Response<PontoModel>) {
                    val responseBodyIncial = response.body()
                    carregarBotoes(view, responseBodyIncial)
                }

                override fun onFailure(call: Call<PontoModel>, t: Throwable) {
                    carregarBotoes(view, null)
                }
            })
        }

        backButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(MenuFragment(), false)
        }

        entradaButton.setOnClickListener {
            val tipoPonto = TipoPonto("entrada")
            registrarPonto(tipoPonto, view)
        }
        pausaButton.setOnClickListener {
            val tipoPonto = TipoPonto("pausa")
            registrarPonto(tipoPonto, view)
        }
        retornoButton.setOnClickListener {
            val tipoPonto = TipoPonto("retorno")
            registrarPonto(tipoPonto, view)
        }
        saidaButton.setOnClickListener {
            val tipoPonto = TipoPonto("saida")
            registrarPonto(tipoPonto, view)
        }
    }
    @SuppressLint("SetTextI18n")
    fun registrarPonto(tipoPonto: TipoPonto, view : View) {

        val mensagemPonto = view.findViewById<TextView>(R.id.ponto_registrado_text)

        val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
        val callRegistrarPonto: Call<PontoModel> = userAPI.registrarPonto(tipoPonto)

        var responseBody : PontoModel?

        lifecycleScope.launch {
            try {
                callRegistrarPonto.enqueue(object :
                    Callback<PontoModel> {
                    override fun onResponse(
                        call: Call<PontoModel>,
                        response: Response<PontoModel>
                    ) {
                        responseBody = response.body()
                        carregarBotoes(view, responseBody)
                        mensagemPonto.text = "Ponto registrado com sucesso"
                    }

                    override fun onFailure(call: Call<PontoModel>, t: Throwable) {
                        responseBody = null
                        carregarBotoes(view, responseBody)
                        mensagemPonto.text = "Erro ao registrar ponto"
                    }
                })
            } catch (e: Exception) {
                Log.d("Erro busca:", e.stackTraceToString())
            }
        }
    }

    @SuppressLint("SetTextI18n")
    fun carregarBotoes(view : View, responseBody : PontoModel?){
        val entradaButton = view.findViewById<Button>(R.id.entrada_button)
        val pausaButton = view.findViewById<Button>(R.id.pausa_button)
        val retornoButton = view.findViewById<Button>(R.id.retorno_button)
        val saidaButton = view.findViewById<Button>(R.id.saida_button)

        entradaButton.isEnabled = false
        pausaButton.isEnabled = false
        retornoButton.isEnabled = false
        saidaButton.isEnabled = false

        if (responseBody != null) {
            entradaButton.text = "Entrada \n ${responseBody.entrada?.slice(IntRange(0,7)).orEmpty()}"
            pausaButton.text = "Pausa \n ${responseBody.saidaAlmoco?.slice(IntRange(0,7)).orEmpty()}"
            retornoButton.text = "Retorno \n ${responseBody.retornoAlmoco?.slice(IntRange(0,7)).orEmpty()}"
            saidaButton.text = "Saida \n ${responseBody.saida?.slice(IntRange(0,7)).orEmpty()}"

            if (responseBody.entrada == null) {
                entradaButton.isEnabled = true
            } else if (responseBody.saidaAlmoco == null) {
                pausaButton.isEnabled = true
            } else if (responseBody.retornoAlmoco == null) {
                retornoButton.isEnabled = true
            } else if (responseBody.saida == null) {
                saidaButton.isEnabled = true
            }
        }
    }

    companion object
}
