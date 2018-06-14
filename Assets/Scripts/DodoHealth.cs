using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DodoHealth : MonoBehaviour {

    public SOFloat timeToLive;
    public float timeToLiveMax = 45;
    public AudioClip[] ouchClips;               // Array of clips to play when the player is damaged.
    public float damageAmount;            // The amount of damage to take when enemies touch the player

    public float damageBasic;
    public float damageAdept;
    public float damageElite;
    public float timeAdded;

    private bool timeLeft = true;
    private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Animator anim;						// Reference to the Animator on the player

    void Awake()
    {
        // Setting up references.
        playerControl = GetComponent<PlayerControl>();
        //anim = GetComponent<Animator>();
        timeToLive.Reset();
    }

    void Update()
    {

        if (timeToLive.FloatValue >= timeToLiveMax)
        {
<<<<<<< HEAD
            timeToLive.FloatValue = timeToLiveMax;
=======
            Dead();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            
>>>>>>> 72682c071e6c790b21f435151b27450e2c738b6b
        }

        timeToLive.FloatValue -= Time.deltaTime;
        Debug.Log(timeToLive.FloatValue);

        if (timeToLive.FloatValue <= 0)
        {
            Dead();
        }

        //UpdateTimeDisplay(timeToLive);
    }


    private void Dead() {
        reloadLevel();     
    }

    public void reloadLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void BasicHit()
    {
        timeToLive.FloatValue = timeToLive.FloatValue - damageBasic;
    }

    public void AdeptHit()
    {
        timeToLive.FloatValue = timeToLive.FloatValue - damageAdept;
    }

    public void EliteHit()
    {
        timeToLive.FloatValue = timeToLive.FloatValue - damageAdept;   
    }

    public void EnemyDead() {
        timeToLive.FloatValue += timeAdded;
    }
    /*
    public void UpdateTimeDisplay(float time)
    {
        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f)
        {
            timeToLive = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: Dodo is Dead ";
        }
    }*/
}
