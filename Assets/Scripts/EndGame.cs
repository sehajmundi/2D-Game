using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame: MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Application.LoadLevel("End");
        }
    }
}
