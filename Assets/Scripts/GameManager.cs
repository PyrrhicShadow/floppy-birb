using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {

    [SerializeField] int playerScore; 
    [SerializeField] Text scoreText; 
    [SerializeField] GameObject gameOverScreen; 
    [SerializeField] GameObject gameStartScreen; 
    [SerializeField] Bird bird; 
    [SerializeField] PipeSpawner pipeSpawner; 
    private AudioManager audioManager; 

    private void Start() {
        audioManager = GameObject.FindWithTag("AudioController").GetComponent<AudioManager>(); 
    }

    public void Begin() {
        bird.Begin(); 
        pipeSpawner.Begin(); 
        gameStartScreen.SetActive(false); 
    }

    [ContextMenu("Add Score")]
    public void AddScore(int score) {
        playerScore = playerScore + score; 
        scoreText.text = playerScore.ToString(); 
        audioManager.Score(); 
    }

    public void RestartGame() {
        // reload this scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void GameOver() {
        gameOverScreen.SetActive(true); 
    }
}
