package com.example.deltarhmobile

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentTransaction
import com.example.deltarhmobile.ui.LoginFragment

class MainActivity : AppCompatActivity(), NavigationHost {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        if(savedInstanceState == null){
            supportFragmentManager
                .beginTransaction()
                .add(R.id.container, LoginFragment())
                .commit()
        }
    }

    override fun navigateTo(fragment: Fragment, addToBackStack: Boolean) {
        val transaction : FragmentTransaction = supportFragmentManager
            .beginTransaction()
            .replace(R.id.container, fragment)

        if(addToBackStack) {
            transaction.addToBackStack(null)
        }

        transaction.commit()
    }
}