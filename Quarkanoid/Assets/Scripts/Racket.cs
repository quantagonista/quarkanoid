using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
    public float speed = 150;
    private int playerLives;
    private int playerPoints;
    
    void Start () {
        playerLives = 3;
        playerPoints = 0;
    }
    
    void FixedUpdate () {
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    
        if (playerLives == 0){
            lose();
        }
        
        if ((GameObject.FindGameObjectsWithTag ("Block")).Length == 0) {
            win();
        }
        
        
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
    
    void addPoints(int points){
        playerPoints += points;
    }
    
    void OnGUI(){
        GUI.contentColor = Color.black;
        GUI.Label(
            new Rect(5.0f,3.0f,200.0f,200.0f),
            "Live's: " + playerLives + "  Score: " + playerPoints
        );
    }
    
    void takeLife(){
        playerLives--;
        transform.position = new Vector3(0,-106,0);
    }
    
    void win(){
        Application.LoadLevel("WinScene");
    }
    
    
    void lose(){
        Application.LoadLevel("LoseScene");
    }
}
