package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class UserRequest (
    @SerializedName("cpf")
    var cpf: String,
    @SerializedName("password")
    var password: String,
    @SerializedName("isLogged")
    var isLogged: Boolean
)