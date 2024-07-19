using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicManager : MonoBehaviour
{ 
    public GameObject gameOverScreen;
    public float health = 7f;
    public Text healthScore;
    public float trash = 0f;
    public Text trashScore;
    public SetBg setBg;
    public string bgName;
    [ContextMenu("Increase Score") ]

    public void decreaseHealth(float x)
    {
        health = health - x;
        healthScore.text = health.ToString();
    }
    public void increaseScore(float x)
    {
        trash = trash + x;
        trashScore.text = trash.ToString();
        
    }
   
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }
}
