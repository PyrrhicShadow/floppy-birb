using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour {

    [SerializeField] int playerScore; 
    [SerializeField] Text scoreText; 

    [ContextMenu("Add Score")]
    public void AddScore(int score) {
        playerScore = playerScore + score; 
        scoreText.text = playerScore.ToString(); 
    }
}
