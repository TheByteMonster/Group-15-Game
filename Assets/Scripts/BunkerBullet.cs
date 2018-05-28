using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerBullet : MonoBehaviour {

    public GameObject explosion;        // Prefab of explosion effect.
    public float damagedTime;


    void Start()
    {
        // Destroy the rocket after 0.2 seconds if it doesn't get destroyed before then.
        //
        Destroy(gameObject, 2f);
    }

    // change later
    void OnTriggerEnter2D(Collider2D col)
    {
        // If it hits an player...
        if (col.tag == "Player")
        {

            col.gameObject.GetComponent<PlayerHealth>().hurt();

            // Destroy the rocket.
            Destroy(gameObject);
        }
    }
}
