using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour {

    [SerializeField] int playerScore; 
    [SerializeField] Text scoreText; 
    [SerializeField] Text highScoreText; 
    [SerializeField] GameObject gameOverScreen; 
    [SerializeField] Bird bird; 
    [SerializeField] PipeSpawner pipeSpawner; 
    private AudioManager audioManager; 

    private void Start() {
        audioManager = GameObject.FindWithTag("AudioController").GetComponent<AudioManager>(); 
        highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString(); 
        Begin(); 
    }

    public void Begin() {
        bird.Begin(); 
        pipeSpawner.Begin(); 
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
        PlayerPrefs.SetInt("highscore", playerScore); 
    }
}
