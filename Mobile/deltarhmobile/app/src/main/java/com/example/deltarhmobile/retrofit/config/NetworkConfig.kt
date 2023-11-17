package com.example.deltarhmobile.retrofit.config

import android.content.Context
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.util.concurrent.TimeUnit

object NetworkConfig {

    lateinit var context : Context
    private const val BASE_URL = "http://10.0.2.2:5091"

    fun <T> provideApi(clazz: Class<T>, context: Context?): T{

        val retrofit = Retrofit
            .Builder()
            .addConverterFactory(GsonConverterFactory.create())
            .baseUrl(BASE_URL)
            .client(okHttpClient(context))
            .build()
        return retrofit.create(clazz)
    }

    private fun okHttpClient(context : Context?): OkHttpClient {
        return OkHttpClient.Builder()
            .readTimeout(15, TimeUnit.SECONDS)
            .connectTimeout(15, TimeUnit.SECONDS)
            .addInterceptor(AuthInterceptor(context))
            .build()
    }
}