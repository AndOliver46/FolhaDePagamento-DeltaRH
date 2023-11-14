package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class HoleriteModel(
    @SerializedName("id_holerite") val idHolerite: Int,
    @SerializedName("nome_empresa") val nomeEmpresa: String,
    @SerializedName("cnpj_empresa") val cnpjEmpresa: String,
    @SerializedName("periodo_inicio") val periodoInicio: String,
    @SerializedName("periodo_fim") val periodoFim: String,
    @SerializedName("id_folhadepagamento") val idFolhaDePagamento: Int,
    @SerializedName("id_colaborador") val idColaborador: Int,
    @SerializedName("nome_colaborador") val nomeColaborador: String,
    @SerializedName("cargo_colaborador") val cargoColaborador: String,
    @SerializedName("horas_trab") val horasTrabalhadas: String,
    @SerializedName("porcentagem_vt") val porcentagemVT: Double,
    @SerializedName("porcentagem_vr") val porcentagemVR: Double,
    @SerializedName("porcentagem_assis_odonto") val porcentagemAssistenciaOdonto: Double,
    @SerializedName("porcentagem_assis_medica") val porcentagemAssistenciaMedica: Double,
    @SerializedName("porcentagem_adiantamento") val porcentagemAdiantamento: Double,
    @SerializedName("porcentagem_gympass") val porcentagemGympass: Double,
    @SerializedName("horas_extras") val horasExtras: String,
    @SerializedName("salario_base") val salarioBase: Double,
    @SerializedName("total_vencimentos") val totalVencimentos: Double,
    @SerializedName("total_descontos") val totalDescontos: Double,
    @SerializedName("salario_liq") val salarioLiquido: Double,
    @SerializedName("mes_ano_ref") val mesAnoReferencia: String,

    @SerializedName("valor_horas_extras") val valorHorasExtras: Double,
    @SerializedName("horas_atraso") val horasAtraso: String,
    @SerializedName("valor_desc_atrasos") val valorDescAtrasos: Double,
    @SerializedName("desconto_inss") val descontoINSS: Double,
    @SerializedName("desconto_irrf") val descontoIRRF: Double
)
