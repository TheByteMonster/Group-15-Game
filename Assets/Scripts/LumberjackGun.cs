using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackGun : MonoBehaviour {

    public Rigidbody2D blast;              // Prefab of the rocket.
    public float speed = 20f;				// The speed the rocket will fire at.
    public float range;
    public float fireRate = 1f;
    public bool allowFire = true;
    public Transform sightStart, sightEnd;
    public bool facingLeft = true;
    public bool spotted;


    private Lumberjack lumberjack;       // Reference to the PlayerControl script.
    private Animator anim;                  // Reference to the Animator component.
    private PlayerControl target; 
    


    void Awake()
    {
        // Setting up the references.
        anim = transform.root.gameObject.GetComponent<Animator>();
        //playerCtrl = transform.root.GetComponent<PlayerControl>();
    }

    void Update()
    {
        //var dir = target.position.x - transform.position;
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        fireWeapon();
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

    public void fireWeapon()
    {

        // If the fire button is pressed...
        if (spotted == true && (allowFire))
        {

            // ... set the animator Shoot trigger parameter and play the audioclip.
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();

            // If the player is facing right...
            if (lumberjack.patrol() == "left")
            {
                // ... instantiate the rocket facing right and set it's velocity to the right.
                Rigidbody2D bulletInstance = Instantiate(blast, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                bulletInstance.velocity = new Vector2(speed, 0);
                StartCoroutine(rateOfFireController());

            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(blast, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
                StartCoroutine(rateOfFireController());
            }
        }
    }

    IEnumerator rateOfFireController()
    {

        allowFire = false;
        yield return new WaitForSeconds(.4f);
        allowFire = true;
    }
}
