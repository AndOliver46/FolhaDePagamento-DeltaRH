package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName
import java.sql.Date
import java.sql.Time

data class PontoModel(
    @SerializedName("id_pontoeletronico")
    val idPontoeletronico: Int,
    @SerializedName("data")
    val data: String,
    @SerializedName("entrada")
    val entrada: String?,
    @SerializedName("saida_almoco")
    val saidaAlmoco: String?,
    @SerializedName("retorno_almoco")
    val retornoAlmoco: String?,
    @SerializedName("saida")
    val saida: String?,
    @SerializedName("tipo_justificativa")
    val tipoJustificativa: String?,
    @SerializedName("descricao")
    val descricao: String?,
    @SerializedName("documento")
    val documento: ByteArray?,
    @SerializedName("id_colaborador")
    val idColaborador: Int
)
