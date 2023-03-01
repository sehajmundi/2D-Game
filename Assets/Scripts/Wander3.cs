using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander3 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private Animator _anim;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
    }
}
