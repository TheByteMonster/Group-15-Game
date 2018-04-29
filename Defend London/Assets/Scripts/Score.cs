using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.
    public float time;
    private bool stopTimer = false;


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}


	void Update ()
	{
        time -= Time.deltaTime;

        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");
        Debug.Log("Timer = 0");

        if (Time.deltaTime == 0)
        {
            //time = 0;
            stopTimer = true;
            Debug.Log("Timer = 0");
        }
        //stop timer
        //kill player

        // If the score has changed...
        //if(previousScore != score)
        // ... play a taunt.
        //playerControl.StartCoroutine(playerControl.Taunt());

        // Set the previous score to this frame's score.
        //previousScore = score;
    }

}
