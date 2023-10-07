package com.example.deltarhmobile

import androidx.fragment.app.Fragment

interface NavigationHost {
    fun navigateTo(fragment: Fragment, addToBackStack: Boolean)
}