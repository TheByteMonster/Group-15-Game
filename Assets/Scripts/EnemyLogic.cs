﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public Transform sightStart, sightEnd;

    public bool spotted = false; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RayCasting();
        Behaviours();
	}
    void RayCasting() {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.DrawLine(sightStart.position,sightEnd.position,Color.green);
        spotted = Physics2D.Linecast(sightStart.position, playerPosition);

    }

    void Behaviours() {

    }
}
