package com.example.deltarhmobile.ui

import android.graphics.Color
import android.os.Build
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.annotation.RequiresApi
import androidx.core.graphics.drawable.toDrawable
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.model.PontoModel
import com.example.deltarhmobile.retrofit.model.TipoPonto
import com.example.deltarhmobile.retrofit.model.UserModel
import retrofit2.Call
import retrofit2.Response
import java.text.SimpleDateFormat
import java.time.Instant
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

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        var dateText = view.findViewById<TextView>(R.id.text_data)
        var timeText = view.findViewById<TextView>(R.id.text_hora)
        val dataHoraAtual = Date()

        val formatoData = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
        val formatoHora = SimpleDateFormat("HH:mm", Locale.getDefault())

        dateText.text = formatoData.format(dataHoraAtual)
        timeText.text = formatoHora.format(dataHoraAtual)

        val backButton = view.findViewById<Button>(R.id.button_back)
        backButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(MenuFragment(), false)
        }

        carregarBotoes(view)

        val entradaButton = view.findViewById<Button>(R.id.entrada_button)
        val pausaButton = view.findViewById<Button>(R.id.pausa_button)
        val retornoButton = view.findViewById<Button>(R.id.retorno_button)
        val saidaButton = view.findViewById<Button>(R.id.saida_button)

        val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
        entradaButton.setOnClickListener{
            val tipoPonto = TipoPonto("entrada")
            val callRegistrarPonto: Call<PontoModel> = userAPI.registrarPonto(tipoPonto)
            val response: Response<PontoModel> = callRegistrarPonto.execute()
            var responseBody = response.body()

            carregarBotoes(view)
        }
        pausaButton.setOnClickListener{
            val tipoPonto = TipoPonto("pausa")
            val callRegistrarPonto: Call<PontoModel> = userAPI.registrarPonto(tipoPonto)
            val response: Response<PontoModel> = callRegistrarPonto.execute()
            var responseBody = response.body()

            carregarBotoes(view)
        }
        retornoButton.setOnClickListener{
            val tipoPonto = TipoPonto("retorno")
            val callRegistrarPonto: Call<PontoModel> = userAPI.registrarPonto(tipoPonto)
            val response: Response<PontoModel> = callRegistrarPonto.execute()
            var responseBody = response.body()

            carregarBotoes(view)
        }
        saidaButton.setOnClickListener{
            val tipoPonto = TipoPonto("saida")
            val callRegistrarPonto: Call<PontoModel> = userAPI.registrarPonto(tipoPonto)
            val response: Response<PontoModel> = callRegistrarPonto.execute()
            var responseBody = response.body()

            carregarBotoes(view)
        }
    }

    fun carregarBotoes(view : View){
        try {
            val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
            val callCarregarPonto: Call<PontoModel> = userAPI.carregarPonto()
            val response: Response<PontoModel> = callCarregarPonto.execute()
            var responseBody = response.body()

            val entradaButton = view.findViewById<Button>(R.id.entrada_button)
            val pausaButton = view.findViewById<Button>(R.id.pausa_button)
            val retornoButton = view.findViewById<Button>(R.id.retorno_button)
            val saidaButton = view.findViewById<Button>(R.id.saida_button)

            entradaButton.isEnabled = false
            pausaButton.isEnabled = false
            retornoButton.isEnabled = false
            saidaButton.isEnabled = false

            if(response.isSuccessful){
                if (responseBody != null) {
                    if (responseBody.entrada == null) {
                        entradaButton.isEnabled = true
                    }else if (responseBody.saidaAlmoco == null) {
                        pausaButton.isEnabled = true
                    }else if (responseBody.retornoAlmoco == null) {
                        retornoButton.isEnabled = true
                    }else if (responseBody.saida == null) {
                        saidaButton.isEnabled = true
                    }
                }
            }
        }catch (e : Exception){
            Log.d("Erro busca:", e.stackTraceToString())
        }
    }


    companion object {

    }
}