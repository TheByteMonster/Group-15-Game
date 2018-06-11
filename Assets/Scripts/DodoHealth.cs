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

    private bool timeLeft = true;
    private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Animator anim;						// Reference to the Animator on the player

    void Awake()
    {
        // Setting up references.
        playerControl = GetComponent<PlayerControl>();
        timetoLiveTxt = GetComponent<Text>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        timeToLive -= Time.deltaTime;
        Debug.Log(timeToLive);

        if (timeToLive >= timeToLiveMax) {
            timeToLive = timeToLiveMax;
        }
        UpdateTimeDisplay(timeToLive);
    }

    public void hurt()
    {
        //timeToLive -= damageAmount;
        Debug.Log("Dodo hit");

        //int i = Random.Range(0, ouchClips.Length);
        //AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
        /*
        if (timeToLive <= 0) {
            Dead();
        }*/
    }

    private void Dead() {
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        reloadLevel();     
    }
    
    public void UpdateTimeDisplay(float time)
    {
        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f)
        {
            timeToLive = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("0");
        }
    }

    public void reloadLevel() {
        //Application.LoadLevel(Application.loadedLevel);
    }
}
