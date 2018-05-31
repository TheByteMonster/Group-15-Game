using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour {

    public bool spotted;
    public Vector2 direction;
    public Ray sight;
    public float healthPoints;
    public Transform sightStart, sightEnd;
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
        rayCast();

    }

    void FixedUpdate()
    {

        // If the enemy has zero or fewer hit points and isn't dead yet...
        if (healthPoints <= 0 && !dead) {

        }
  
    }

    //for the raycast
    bool rayCast()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (spotted = Physics2D.Linecast(sightStart.position, playerPosition,
        1 << LayerMask.NameToLayer("floor")))
        {// floor is a placeholder
            return false;
        }
        else if (spotted = Physics2D.Linecast(sightStart.position, playerPosition,
            1 << LayerMask.NameToLayer("Player")))
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    private void shoot() {

        // If the fire button is pressed...
        if (spotted == true && (allowFire))
        {

            // ... set the animator Shoot trigger parameter and play the audioclip.
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();

            //get angle of gun 
            //move projectile along angle
            /*if (lumberjack.patrol() == "left")
            {
                // ... instantiate the rocket facing right and set it's velocity to the right.
                Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                bulletInstance.velocity = new Vector2(speed, 0);
                StartCoroutine(rateOfFireController());

            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
                StartCoroutine(rateOfFireController());
            }*/
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
        healthPoints -= 50;
    }

    void Death() {

    }


    IEnumerator rateOfFireController()
    {

        allowFire = false;
        yield return new WaitForSeconds(.4f);
        allowFire = true;
    }
}
