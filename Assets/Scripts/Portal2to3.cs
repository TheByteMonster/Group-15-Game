﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;  // To manage scene load
using UnityEngine;

public class Portal2to3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Load Level3 scene when collides
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Portal prefab")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}