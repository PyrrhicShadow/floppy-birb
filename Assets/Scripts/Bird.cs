using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Bird : MonoBehaviour {

    [SerializeField] Rigidbody2D myRigidbody; 
    [SerializeField] float upVelocity; 
    [SerializeField] PlayerInput playerInput; 
    private GameManager manager; 
    private InputAction moveAction; 

    private void Awake() {
        playerInput = this.gameObject.GetComponent<PlayerInput>(); 

        moveAction = playerInput.actions["Fire"]; 
    }

    void Start() {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); 
        myRigidbody = this.gameObject.GetComponent<Rigidbody2D>(); 
        moveAction.Enable(); 
    }

    private void OnEnable() {
        moveAction.performed += _ => Jump(); 

    }

    private void OnDisable() {
        moveAction.performed -= _ => Jump(); 
    }

    public void Jump() {
        myRigidbody.velocity = Vector2.up * upVelocity; 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            manager.GameOver(); 
            KillBird(); 
        }
    }

    public void KillBird() {
        // this.gameObject.SetActive(false); 
        moveAction.Disable(); 
    }
}
