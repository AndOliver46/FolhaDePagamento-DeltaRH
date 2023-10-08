package com.example.deltarhmobile.retrofit.model

import com.google.gson.annotations.SerializedName

data class UserResponse (
    @SerializedName("token")
    var token : String,
    @SerializedName("message")
    var message : String,
    @SerializedName("error")
    var error : Boolean
)