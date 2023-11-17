package com.example.deltarhmobile.ui

import android.annotation.SuppressLint
import android.os.Build
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.annotation.RequiresApi
import androidx.lifecycle.lifecycleScope
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.config.SessionManager
import com.example.deltarhmobile.retrofit.model.UserModel
import kotlinx.coroutines.launch
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MenuFragment : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {

        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_menu, container, false)
    }

    @RequiresApi(Build.VERSION_CODES.O)
    @SuppressLint("SetTextI18n")
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val userName = view.findViewById<TextView>(R.id.text_username)

        lifecycleScope.launch{
            try {
                val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
                val call: Call<UserModel> = userAPI.carregarDados()
                call.enqueue(object : Callback<UserModel> {
                    override fun onResponse(call: Call<UserModel>, response: Response<UserModel>) {
                        if(response.isSuccessful){
                            val responseBody = response.body()
                            if (responseBody != null) {
                                userName.text = responseBody.nome
                            }
                        }
                    }

                    override fun onFailure(call: Call<UserModel>, t: Throwable) {
                        userName.text = "Erro API: Realize login novamente"
                    }
                })
            }catch (e : Exception){
                userName.text = "Erro API: Realize login novamente"
            }
        }

        val registrarPontoButton = view.findViewById<Button>(R.id.registrar_button)
        registrarPontoButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(PontoFragment(), true)
        }

        val registrarJustificativaButton = view.findViewById<Button>(R.id.justificativa_button)
        registrarJustificativaButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(JustificativaFragment(), true)
        }

        val holeritesButton = view.findViewById<Button>(R.id.holerites_button)
        holeritesButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(HoleriteFragment(), true)
        }

        val logoutButton = view.findViewById<Button>(R.id.logout_button)
        logoutButton.setOnClickListener{
            val sessionManager = SessionManager(context)
            sessionManager.removeToken()
            (activity as NavigationHost).navigateTo(LoginFragment(), false)
        }
    }

    companion object
}