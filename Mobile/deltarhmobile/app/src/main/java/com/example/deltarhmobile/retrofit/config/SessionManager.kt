package com.example.deltarhmobile.retrofit.config

import android.content.Context
import android.content.SharedPreferences
import com.example.deltarhmobile.R

class SessionManager(context: Context?) {

    private var prefs: SharedPreferences = context!!.getSharedPreferences(context.getString(R.string.app_name), Context.MODE_PRIVATE)

    companion object {
        const val USER_TOKEN = "user_token"
    }

    fun saveAuthToken(token: String) {
        val editor : SharedPreferences.Editor = prefs.edit()
        editor.putString(USER_TOKEN, token)
        editor.apply()
    }

    fun fetchAuthToken(): String? {
        return prefs.getString(USER_TOKEN, null)
    }

    fun removeToken(){
        val editor: SharedPreferences.Editor = prefs.edit()
        editor.remove(USER_TOKEN)
        editor.apply()
    }
}