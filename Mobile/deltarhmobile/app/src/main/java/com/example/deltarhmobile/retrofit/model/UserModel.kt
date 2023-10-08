package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName
import java.math.BigDecimal
import java.util.Date

data class UserModel(
    @SerializedName("id_colaborador")
    val idColaborador: Int,
    @SerializedName("nome")
    val nome: String?,
    @SerializedName("data_nascimento")
    val dataNascimento: String?,
    @SerializedName("cpf")
    val cpf: String?,
    @SerializedName("salario_bruto")
    val salarioBruto: BigDecimal,
    @SerializedName("senha")
    val senha: String?,
    @SerializedName("tipo_contrato")
    val tipoContrato: String?,
    @SerializedName("carga_horaria")
    val cargaHoraria: Int,
    @SerializedName("logradouro")
    val logradouro: String?,
    @SerializedName("numero")
    val numero: String?,
    @SerializedName("complemento")
    val complemento: String?,
    @SerializedName("bairro")
    val bairro: String?,
    @SerializedName("cep")
    val cep: String?,
    @SerializedName("cidade")
    val cidade: String?,
    @SerializedName("uf")
    val uf: String?,
    @SerializedName("telefone")
    val telefone: String?,
    @SerializedName("telefone2")
    val telefone2: String?,
    @SerializedName("email")
    val email: String?,
    @SerializedName("id_setor")
    val idSetor: Int
)
