using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLogic : MonoBehaviour
{

    public Vector2 initialVelocity = Vector2.right * 10f;

    public logicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        // launch the projectile to the right at a speed of 10
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f;
        logic = GameObject.FindGameObjectsWithTag("logic")[0].GetComponent<logicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > 10)
        {
            Destroy(gameObject);
        }

    }
    // method for collision between enemy and projectile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the projectile collides with an enemy, destroy the enemy
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy>().Die();
            Destroy(gameObject);
            logic.addScore();
        }
    }

}
