using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public GameObject explosion;        // Prefab of explosion effect.
    public float damagedTime;


    void Start()
    {
        // Destroy the rocket after 0.2 seconds if it doesn't get destroyed before then.
        //
        Destroy(gameObject, 1f);
    }


    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }
    // change later
    void OnTriggerEnter2D(Collider2D col)
    {
        // If it hits an player...
        if (col.tag == "Player")
        {

            col.gameObject.GetComponent<PlayerHealth>().hurt();

            // Call the explosion instantiation.
            //unsure if how to kill game object
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
        }
    }
}
