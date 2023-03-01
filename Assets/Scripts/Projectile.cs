using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    [SerializeField] private int _damageInflicted = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player player = collision.gameObject.GetComponent<Player>();
            StartCoroutine(player.DamageCharacter(_damageInflicted, 0.0f));
            gameObject.SetActive(false);
        }
        if(collision.tag == "PowerUp")
        {
            Destroy(gameObject);
        }
    }
}
