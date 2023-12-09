using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicManager : MonoBehaviour
{
    public int playerScore;

    public bool isAlive = true;

    public GameObject spawner;
    public GameObject gameOverScreen;
    public GameObject mainMenuScreen;

    public Text scoreText;

    [ContextMenu("add Score")]
    public void addScore(int score = 1)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();

        if(playerScore<0){
            gameOver();
        }
    }

    public void gameOver()
    {
        // set flag for player death and show game over screen
        isAlive = false;
        gameOverScreen.SetActive(true);
    } 

    // method for resetting the scene
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // mainMenuScreen.SetActive(false);
        // remove the main menu from the active scene
        Destroy(mainMenuScreen);
    }

    public void newGame()
    {
        Debug.Log("new game");
        // hide the main menu screen
        mainMenuScreen.SetActive(false);
        spawner.SetActive(true);
    }


    // enemy appearance methods
    // populate the array with the possible enemy sprites from the resources folder
    // objectsArray = Resources.LoadAll("enemies");
    // int index = Random.Range(0, 3);
    // // print the choosen index
    // Debug.Log("index is "+index);
    // // change the sprite of the enemy to a random sprite from the array
    // // gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)objectsArray[index];
    // gameObject.GetComponent<SpriteRenderer>().sprite = objectsArray[index] as Sprite;



}
