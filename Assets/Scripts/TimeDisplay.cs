using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {

    public float time;
    private bool timeLeft = true;
    public float timeLimit;
    private float updatedTime;

    private DodoHealth health; 

    // Use this for initialization
    void Start () {
        health = GameObject.FindGameObjectWithTag("DodoHealth").GetComponent<DodoHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f)
        {
            time = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("0");
        }
    }
}
