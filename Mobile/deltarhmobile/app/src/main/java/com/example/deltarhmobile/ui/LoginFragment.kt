package com.example.deltarhmobile.ui

import android.os.Build
import android.os.Bundle
import android.os.StrictMode
import android.os.StrictMode.ThreadPolicy
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ProgressBar
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.config.SessionManager
import com.example.deltarhmobile.retrofit.model.UserRequest
import com.example.deltarhmobile.retrofit.model.UserResponse
import com.google.android.material.textfield.TextInputEditText
import retrofit2.Call
import retrofit2.Response


class LoginFragment : Fragment() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {

        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val SDK_INT = Build.VERSION.SDK_INT
        if (SDK_INT > 8) {
            val policy = ThreadPolicy.Builder()
                .permitAll().build()
            StrictMode.setThreadPolicy(policy)
            //your codes here
        }
        return inflater.inflate(R.layout.fragment_login, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val loginButton = view.findViewById<Button>(R.id.entrar_button)

        loginButton.setOnClickListener{

            var cpfInput = view.findViewById<TextInputEditText>(R.id.cpf_edit_text)
            var passwordInput = view.findViewById<TextInputEditText>(R.id.senha_edit_text)

            var cpf = cpfInput.text.toString().trim()
            var password = passwordInput.text.toString().trim()

            if(cpf.isEmpty()){
                cpfInput.error = "Insira o CPF"
                cpfInput.requestFocus()
                return@setOnClickListener
            }

            if(password.isEmpty()){
                passwordInput.error = "Insira a senha"
                passwordInput.requestFocus()
                return@setOnClickListener
            }

            var userRequest = UserRequest(cpf, password, true)

            try {
                val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
                val call: Call<UserResponse> = userAPI.onLogin(userRequest)
                val response: Response<UserResponse> = call.execute()
                var responseBody = response.body()

                if(response.isSuccessful){
                    var token = responseBody?.token

                    val sessionManager = SessionManager(context)
                    if (token != null) {
                        sessionManager.saveAuthToken(token)
                    }

                    (activity as NavigationHost).navigateTo(MenuFragment(), false)
                }else if(response.code() == 401){
                    val errorMessageTextView = view.findViewById<TextView>(R.id.errorMessageTextView)

                    errorMessageTextView.text = "Credenciais inválidas."
                    errorMessageTextView.visibility = View.VISIBLE
                }
            }catch (e : Exception){
                val errorMessageTextView = view.findViewById<TextView>(R.id.errorMessageTextView)
                errorMessageTextView.text = "ERRO DE API"
                errorMessageTextView.visibility = View.VISIBLE
            }

        }

    }

    companion object {

    }
}