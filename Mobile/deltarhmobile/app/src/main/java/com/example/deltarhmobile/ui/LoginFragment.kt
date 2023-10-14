package com.example.deltarhmobile.ui

import android.annotation.SuppressLint
import android.app.AlertDialog
import android.os.Build
import android.os.Bundle
import android.os.StrictMode
import android.os.StrictMode.ThreadPolicy
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
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

    @SuppressLint("SetTextI18n")
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val loginButton = view.findViewById<Button>(R.id.entrar_button)

        loginButton.setOnClickListener{

            val cpfInput = view.findViewById<TextInputEditText>(R.id.cpf_edit_text)
            val passwordInput = view.findViewById<TextInputEditText>(R.id.senha_edit_text)

            val cpf = cpfInput.text.toString().trim()
            val password = passwordInput.text.toString().trim()

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

            val userRequest = UserRequest(cpf, password, true)
            val messageTextView = view.findViewById<TextView>(R.id.message_text_view)

            try {
                val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
                val call: Call<UserResponse> = userAPI.onLogin(userRequest)
                val response: Response<UserResponse> = call.execute()
                val responseBody = response.body()

                if(response.isSuccessful){
                    val token = responseBody?.token
                    val sessionManager = SessionManager(context)

                    if (token != null) {
                        sessionManager.saveAuthToken(token)
                    }

                    (activity as NavigationHost).navigateTo(MenuFragment(), false)
                }else if(response.code() == 401){
                    messageTextView.text = "Credenciais inválidas."
                }
            }catch (e : Exception){
                messageTextView.text = "ERRO DE API"
            }
        }

        val esqueciSenhaButton = view.findViewById<Button>(R.id.esqueci_senha_button)
        esqueciSenhaButton.setOnClickListener{
            val builder = AlertDialog.Builder(requireContext())

            builder.setTitle("Esqueci minha senha")
            builder.setMessage("Entre em contato com o RH da empresa e solicite a alteração da senha!\n\nContato: (11) 91234-5678\nEmail: contato@deltarh.com.br")

            builder.setPositiveButton("OK") { dialog, which ->
                dialog.dismiss()
            }

            val dialog = builder.create()
            dialog.show()
        }

    }

    companion object
}