using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour {

    public Rigidbody2D bullet;              // Prefab of the rocket.
    public float speed;
    public float range;
    public float fireRate = 1f;
    public bool allowFire = true;
    public bool facingLeft = true;
    public RaycastHit2D spotted;
    public float healthPoints;
    public bool dead = false;

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


    public void Damaged()
    {
        healthPoints -= 50;
        Debug.Log(healthPoints);
    }

    void Death()
    {
        dead = true;
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        //int i = Random.Range(0, deathClips.Length);
        //AudioSource.PlayClipAtPoint(deathClips[i], transform.position);
    }


    //for the raycast
    void pointWeapon()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

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
            //anim.SetTrigger("Shoot");
            //GetComponent<AudioSource>().Play();

            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
            Vector3 shootDirection = (playerPos - transform.position).normalized;
            bulletInstance.GetComponent<LumberjackBullet>().timeAlive = range;
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
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
