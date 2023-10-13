package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class JustificativaModel(
    @SerializedName("tipo_justificativa")
    var tipo_justificativa: String,
    @SerializedName("descricao_justificativa")
    var descricao_justificativa: String?,
    @SerializedName("documento")
    var documento: String?
)
