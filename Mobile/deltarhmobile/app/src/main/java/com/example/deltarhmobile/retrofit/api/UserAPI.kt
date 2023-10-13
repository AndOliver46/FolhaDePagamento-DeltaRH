package com.example.deltarhmobile.retrofit.api

import com.example.deltarhmobile.retrofit.model.JustificativaModel
import com.example.deltarhmobile.retrofit.model.PontoModel
import com.example.deltarhmobile.retrofit.model.TipoPonto
import com.example.deltarhmobile.retrofit.model.UserModel
import com.example.deltarhmobile.retrofit.model.UserRequest
import com.example.deltarhmobile.retrofit.model.UserResponse
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface UserAPI {

    @POST("/api/v1/autenticacao/login")
    fun onLogin(@Body userRequest : UserRequest): Call<UserResponse>

    @GET("/api/v1/mobile/carregar-dados-usuario")
    fun carregarDados(): Call<UserModel>

    @GET("/api/v1/mobile/carregar-registro-ponto")
    fun carregarPonto(): Call<PontoModel>

    @POST("/api/v1/mobile/registrar-ponto")
    fun registrarPonto(@Body tipoPonto : TipoPonto) : Call<PontoModel>

    @POST("/api/v1/mobile/registrar-justificativa")
    fun registrarJustificativa(@Body justificativaModel: JustificativaModel) : Call<PontoModel>
}