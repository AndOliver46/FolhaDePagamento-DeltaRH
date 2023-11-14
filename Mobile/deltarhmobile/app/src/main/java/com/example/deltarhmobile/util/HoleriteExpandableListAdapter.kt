import android.annotation.SuppressLint
import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseExpandableListAdapter
import android.widget.TextView
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.model.HoleriteModel

class HoleriteExpandableListAdapter(private val context: Context, private val expandableListDetail: Map<String, List<HoleriteModel>>) :
    BaseExpandableListAdapter() {

    private val months = expandableListDetail.keys.toList()

    override fun getGroupCount(): Int {
        return months.size
    }

    override fun getChildrenCount(groupPosition: Int): Int {
        val month = months[groupPosition]
        return expandableListDetail[month]?.size ?: 0
    }

    override fun getGroup(groupPosition: Int): Any {
        return months[groupPosition]
    }

    override fun getChild(groupPosition: Int, childPosition: Int): Any? {
        val month = months[groupPosition]
        return expandableListDetail[month]?.getOrNull(childPosition)
    }

    override fun getGroupId(groupPosition: Int): Long {
        return groupPosition.toLong()
    }

    override fun getChildId(groupPosition: Int, childPosition: Int): Long {
        return childPosition.toLong()
    }

    override fun hasStableIds(): Boolean {
        return false
    }

    override fun getGroupView(groupPosition: Int, isExpanded: Boolean, convertView: View?, parent: ViewGroup): View {
        val month = getGroup(groupPosition) as String
        val groupView: View = convertView
            ?: LayoutInflater.from(context).inflate(R.layout.list_group, parent, false)

        val monthTextView: TextView = groupView.findViewById(R.id.monthTextView)
        monthTextView.text = month

        return groupView
    }

    @SuppressLint("SetTextI18n")
    override fun getChildView(groupPosition: Int, childPosition: Int, isLastChild: Boolean, convertView: View?, parent: ViewGroup): View {
        val holerite = getChild(groupPosition, childPosition) as HoleriteModel
        val childView: View = convertView
            ?: LayoutInflater.from(context).inflate(R.layout.list_item, parent, false)

        val dadosEmpresaTextView: TextView = childView.findViewById(R.id.dadosEmpresaTextView)
        dadosEmpresaTextView.text = "Empresa: " + holerite.nomeEmpresa + "\nCNPJ: " + holerite.cnpjEmpresa

        val funcaoTextView: TextView = childView.findViewById(R.id.funcaoTextView)
        funcaoTextView.text = "Cargo: " + holerite.cargoColaborador

        val periodoTextView: TextView = childView.findViewById(R.id.periodoTextView)
        periodoTextView.text = "Período: " + holerite.periodoInicio.substring(0,10) + " á " + holerite.periodoFim.substring(0,10)

        val salarioBaseTextView: TextView = childView.findViewById(R.id.vencimentos_salario)
        salarioBaseTextView.text = "R$" + holerite.salarioBase.toString()

        val adiantamentoPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_adiantamento)
        adiantamentoPorcentagemTextView.text = holerite.porcentagemAdiantamento.toString() + "%"
        val adiantamentoValorTextView: TextView = childView.findViewById(R.id.valor_adiantamento)
        val valorAdiantamento = (holerite.salarioBase / 100) * holerite.porcentagemAdiantamento
        adiantamentoValorTextView.text = "R$$valorAdiantamento"

        val horaExtraTextView: TextView = childView.findViewById(R.id.quantidade_horas_extras)
        horaExtraTextView.text = holerite.horasExtras
        val horaExtraValorTextView: TextView = childView.findViewById(R.id.valor_horas_extras)
        horaExtraValorTextView.text = "R$" + holerite.valorHorasExtras.toString()

        val horaAtrasoTextView: TextView = childView.findViewById(R.id.quantidade_horas_atraso)
        horaAtrasoTextView.text = holerite.horasAtraso
        val horaAtrasoValorTextView: TextView = childView.findViewById(R.id.valor_desc_atraso)
        horaAtrasoValorTextView.text = "R$" + holerite.valorDescAtrasos.toString()

        val vtPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_vt)
        vtPorcentagemTextView.text = holerite.porcentagemVT.toString() + "%"
        val vtValorTextView: TextView = childView.findViewById(R.id.valor_desconto_vt)
        val valorVT = (holerite.salarioBase / 100) * holerite.porcentagemVT
        vtValorTextView.text = "R$$valorVT"

        val vrPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_vr)
        vrPorcentagemTextView.text = holerite.porcentagemVR.toString() + "%"
        val vrValorTextView: TextView = childView.findViewById(R.id.valor_desconto_vr)
        val valorVR = (holerite.salarioBase / 100) * holerite.porcentagemVR
        vrValorTextView.text = "R$$valorVR"

        val assisMedicaPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_assisMedica)
        assisMedicaPorcentagemTextView.text = holerite.porcentagemAssistenciaMedica.toString() + "%"
        val assisMedicaValorTextView: TextView = childView.findViewById(R.id.valor_desconto_assisMedica)
        val valorAssisMedica = (holerite.salarioBase / 100) * holerite.porcentagemAssistenciaMedica
        assisMedicaValorTextView.text = "R$$valorAssisMedica"

        val assisOdontoPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_assisOdonto)
        assisOdontoPorcentagemTextView.text = holerite.porcentagemAssistenciaOdonto.toString() + "%"
        val assisOdontoValorTextView: TextView = childView.findViewById(R.id.valor_desconto_assisOdonto)
        val valorAssisOdonto = (holerite.salarioBase / 100) * holerite.porcentagemAssistenciaOdonto
        assisOdontoValorTextView.text = "R$$valorAssisOdonto"

        val gymPassPorcentagemTextView: TextView = childView.findViewById(R.id.porcentagem_gympass)
        gymPassPorcentagemTextView.text = holerite.porcentagemGympass.toString() + "%"
        val gymPassValorTextView: TextView = childView.findViewById(R.id.valor_desconto_gympass)
        val valorGympass = (holerite.salarioBase / 100) * holerite.porcentagemGympass
        gymPassValorTextView.text = "R$$valorGympass"

        val descontoINSSTextView: TextView = childView.findViewById(R.id.valor_desconto_inss)
        descontoINSSTextView.text = "R$" + holerite.descontoINSS.toString()

        val descontoIRFFTextView: TextView = childView.findViewById(R.id.valor_desconto_irrf)
        descontoIRFFTextView.text = "R$" + holerite.descontoIRRF.toString()

        val totalVencimentosTextView: TextView = childView.findViewById(R.id.total_vencimentos)
        totalVencimentosTextView.text = "R$" + holerite.totalVencimentos

        val totalDescontosTextView: TextView = childView.findViewById(R.id.total_descontos)
        totalDescontosTextView.text = "R$" + holerite.totalDescontos

        val totalSalarioTextView: TextView = childView.findViewById(R.id.salario_liquido)
        totalSalarioTextView.text = "R$" + holerite.salarioLiquido

        return childView
    }

    override fun isChildSelectable(groupPosition: Int, childPosition: Int): Boolean {
        return true
    }
}
