using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackGun : MonoBehaviour {

    public Rigidbody2D bullet;              // Prefab of the rocket.
    public float speed;				
    public float range;
    public float fireRate = 1f;
    public bool allowFire = true;
    public bool facingLeft = true;
    public RaycastHit2D spotted;

    private float angle;
    private Animator anim;                  // Reference to the Animator component.
    private PlayerController target;
    private float dir;
    private GameObject gun;
    


    void Awake()
    {
        // Setting up the references.
        anim = transform.root.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        pointWeapon();
    }


    private void FixedUpdate()
    {
        pointWeapon();
    }

    //for the raycast
    void pointWeapon()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        Quaternion rotation = Quaternion.LookRotation(playerPosition - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        Debug.DrawLine(transform.position, playerPosition, Color.green);

        if (spotted = Physics2D.Linecast(transform.position, playerPosition))
        {
            if (spotted.collider.CompareTag("Player"))
                fireWeapon(spotted.transform.position);
        }
    }

    public void fireWeapon(Vector3 playerPos)
    {
       if ((allowFire))
        {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            //anim.SetTrigger("Shoot");
            //GetComponent<AudioSource>().Play();

            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
            Vector3 shootDirection = (playerPos - transform.position).normalized;
            bulletInstance.GetComponent<Rocket>().timeAlive = range;
            bulletInstance.velocity = new Vector2(shootDirection.x*speed, shootDirection.y*speed);
            StartCoroutine(rateOfFireController());
        }
    }

    IEnumerator rateOfFireController()
    {
        allowFire = false;
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
