using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
	    
        if (Input.GetButtonDown ("Jump") == true) {
		    Application.LoadLevel("MainScene");
        }
    }
}
