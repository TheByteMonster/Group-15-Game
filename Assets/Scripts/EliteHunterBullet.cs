using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteHunterBullet : MonoBehaviour {

    public GameObject explosion;		// Prefab of explosion effect.
    public float timeAlive;

    void Start()
    {
        Destroy(gameObject, timeAlive);
    }
    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            // ... find the Enemy script and call the Hurt function.
            col.gameObject.GetComponent<PlayerControl>().EliteTranqHit();

            OnExplode();
            Destroy(gameObject);
        }
    }
}
