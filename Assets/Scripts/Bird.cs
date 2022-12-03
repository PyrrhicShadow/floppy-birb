using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Bird : MonoBehaviour {

    private Rigidbody2D myRigidbody; 
    [SerializeField] float upVelocity; 
    private CharacterController controller; 
    private GameManager manager; 
    private PlayerInput playerInput; 
    private InputAction moveAction; 

    private void Awake() {
        controller = this.gameObject.GetComponent<CharacterController>(); 
        playerInput = this.gameObject.GetComponent<PlayerInput>(); 

        moveAction = playerInput.actions["Fire"]; 

        myRigidbody = this.gameObject.GetComponent<Rigidbody2D>(); 
    }

    void Start() {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); 
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
        this.gameObject.SetActive(false); 
    }
}
