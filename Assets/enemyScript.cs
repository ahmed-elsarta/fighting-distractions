using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move to the left at a rate equal to speed
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // if the enemy is off the screen to the left, destroy it
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    // method for enemy dying
    public void Die()
    {
        // destroy the enemy
        Destroy(gameObject);
    }
}
