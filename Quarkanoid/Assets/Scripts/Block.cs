using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collisionInfo) {
        Destroy(gameObject);
        GameObject racket = GameObject.FindGameObjectsWithTag("Racket")[0];
        racket.SendMessage("addPoints", 10);
    }
}
