using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseZone : MonoBehaviour
{
    public logicManager logic;

    private void Start() {
        logic = GameObject.FindGameObjectsWithTag("logic")[0].GetComponent<logicManager>();
    }    

    // if the enemies leave the screen, decrease score by one.
    private void OnTriggerEnter2D(Collider2D collision) {
            Debug.Log("enemy left the screen");
            logic.addScore(-1);
    }

}
