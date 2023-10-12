package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class PontoModel(
    @SerializedName("id_pontoeletronico")
    var idPontoeletronico: Int,
    @SerializedName("data")
    var data: String,
    @SerializedName("entrada")
    var entrada: String?,
    @SerializedName("saida_almoco")
    var saidaAlmoco: String?,
    @SerializedName("retorno_almoco")
    var retornoAlmoco: String?,
    @SerializedName("saida")
    var saida: String?,
    @SerializedName("tipo_justificativa")
    var tipoJustificativa: String?,
    @SerializedName("descricao")
    var descricao: String?,
    @SerializedName("documento")
    var documento: String?,
    @SerializedName("id_colaborador")
    var idColaborador: Int
)
