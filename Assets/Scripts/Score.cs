using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.
    public float time;
    private bool timeLeft = true;
    public float timeLimit;


	private PlayerControl playerControl;	// Reference to the player control script.
	//private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }


	void Update ()
	{
        time -= Time.deltaTime;

        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f) {
            time = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("0");
            //kill player here

        }
    }


     public void addTime() {
        //set limit on the timer 
        //Code also in health pickup. Unsure how we want to increment the time available
        if (time >= 25f) {
            time = 25f;
        }
        else
        {
            time += 5;
        }
        
    }

}
