using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnewlevel : MonoBehaviour {

	// Use this for initialization
        public void loadmenu()
        {
            if (GameObject.FindWithTag("AdaptHunter11") == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
}
