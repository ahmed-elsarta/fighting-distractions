using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    
    public logicManager logic;

    public GameObject projectilePrefab;
    // public float projectileSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        logic = GameObject.FindGameObjectsWithTag("logic")[0].GetComponent<logicManager>();
    }

    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
            verticalInput = 1f;
        else if (Input.GetKey(KeyCode.S))
            verticalInput = -1f;

        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;

        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        rb.velocity = direction * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        
        // summon the projectile n-units to the right of the player
        Vector3 spawnPosition = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
    }

    // destroy the player if it hits an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            // kill the player and notify the log manager script
            Destroy(gameObject);
            logic.gameOver();
        }
    }

}
