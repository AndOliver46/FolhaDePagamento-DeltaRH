package com.example.deltarhmobile.ui

import HoleriteExpandableListAdapter
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ExpandableListView
import androidx.fragment.app.Fragment
import com.example.deltarhmobile.NavigationHost
import com.example.deltarhmobile.R
import com.example.deltarhmobile.retrofit.api.UserAPI
import com.example.deltarhmobile.retrofit.config.NetworkConfig
import com.example.deltarhmobile.retrofit.model.HoleriteModel
import retrofit2.Call
import retrofit2.Response

class HoleriteFragment : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_holerite, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val backButton = view.findViewById<Button>(R.id.button_back_holerite)
        backButton.setOnClickListener{
            (activity as NavigationHost).navigateTo(MenuFragment(), false)
        }

        try {
            val userAPI: UserAPI = NetworkConfig.provideApi<UserAPI>(UserAPI::class.java, context)
            val call: Call<List<HoleriteModel>> = userAPI.carregarHolerites()
            val response: Response<List<HoleriteModel>> = call.execute()
            val responseBody = response.body()

            if (responseBody != null) {
                // Organize os dados em um formato adequado para a ExpandableListView
                val expandableListDetail = HashMap<String, MutableList<HoleriteModel>>()

                for (holerite in responseBody) {
                    val mesAnoReferencia = holerite.mesAnoReferencia
                    if (expandableListDetail.containsKey(mesAnoReferencia)) {
                        expandableListDetail[mesAnoReferencia]?.add(holerite)
                    } else {
                        expandableListDetail[mesAnoReferencia] = mutableListOf(holerite)
                    }
                }

                val expandableListView = view.findViewById<ExpandableListView>(R.id.lista_holerites)

                // Crie e defina o adaptador para a ExpandableListView
                val listaOrdenada = expandableListDetail.toSortedMap()
                val expandableListAdapter = HoleriteExpandableListAdapter(requireContext(), listaOrdenada)

                expandableListView.setAdapter(expandableListAdapter)
            }
        } catch (e: Exception) {
            Log.d("Erro buscando holerites", e.stackTraceToString())
        }
    }



    companion object {
    }
}