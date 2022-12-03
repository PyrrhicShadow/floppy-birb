using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {

    [SerializeField] int playerScore; 
    [SerializeField] Text scoreText; 
    [SerializeField] GameObject gameOverScreen; 

    [ContextMenu("Add Score")]
    public void AddScore(int score) {
        playerScore = playerScore + score; 
        scoreText.text = playerScore.ToString(); 
    }

    public void RestartGame() {
        // reload this scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void GameOver() {
        gameOverScreen.SetActive(true); 
    }
}
