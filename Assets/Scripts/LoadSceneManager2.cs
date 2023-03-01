using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneManager2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Application.LoadLevel("Level 3");
        }
    }
}
