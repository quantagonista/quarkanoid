using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 100.0f;
    private bool isActive = false;
    
    void Start () {
        activate();  
    }
    
    void Update(){
        if(!isActive){
            activate();
        }
        
        if(transform.position.y <= -120.0f){
            GameObject racket = GameObject.FindGameObjectsWithTag("Racket")[0];
            racket.SendMessage("takeLife");
            transform.position = new Vector3(0,-90,0);
            isActive = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "racket") {
            float x=hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }   
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    
    void activate(){
        if (Input.GetButtonDown ("Jump") == true) {
            isActive = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
