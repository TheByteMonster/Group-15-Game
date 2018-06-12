using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DodoHealth : MonoBehaviour {

    public float timeToLive = 35;
    public float timeToLiveMax = 45;
    public AudioClip[] ouchClips;               // Array of clips to play when the player is damaged.
    public float damageAmount;            // The amount of damage to take when enemies touch the player
    public Text timetoLiveTxt;
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
    }

    void Update()
    {

        if (timeToLive >= timeToLiveMax)
        {
            timeToLive = timeToLiveMax;
        }

        timeToLive -= Time.deltaTime;
        Debug.Log(timeToLive);

        if (timeToLive <= 0)
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
        timeToLive = timeToLive - damageBasic;

    }

    public void AdeptHit()
    {
        timeToLive = timeToLive - damageAdept;

    }

    public void EliteHit()
    {
        timeToLive = timeToLive - damageAdept;
      
    }

    public void EnemyDead() {

        timeToLive += timeAdded;
    }

    public void UpdateTimeDisplay(float time)
    {
        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f)
        {
            timeToLive = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: Dodo is Dead ";
        }
    }
}
