using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour {

    public bool spotted;
    public Ray sight;
    public float health = 200;
    public bool dead = false;
    public bool allowFire = true;
    public float speed = 20f;
    public Rigidbody2D bullet;

    private Animator anim;
    private PlayerControl player;


    // Use this for initialization
    void Start()
    {
        rayCast();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rayCast();
        // If the enemy has zero or fewer hit points and isn't dead yet...
        if (health <= 0 && !dead) {

        }
  
    }

    void rayCast()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (spotted = Physics2D.Linecast(transform.position, playerPosition,
      1 << LayerMask.NameToLayer("ground")))
        {
            //nothing happens
        }
        else if (spotted = Physics2D.Linecast(transform.position, playerPosition,
            1 << LayerMask.NameToLayer("Player")))
        {
            shoot();
        }
    }

    private void shoot() {

        // If the fire button is pressed...
        if (spotted == true && (allowFire))
        {

            // ... set the animator Shoot trigger parameter and play the audioclip.
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();

            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            bulletInstance.velocity = new Vector2(speed, 0);
            StartCoroutine(rateOfFireController());
        }
    }

    public void Hurt(Transform col)
    {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "blast")
        {
           Damaged();
        }

    }

    void Damaged()
    {
        health -= 50;
    }

    void Death() {

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
    }

    IEnumerator rateOfFireController()
    {
        allowFire = false;
        yield return new WaitForSeconds(.4f);
        allowFire = true;
    }
}
