package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class TipoPonto(
    @SerializedName("tipo_ponto")
    var tipoPonto: String,
)