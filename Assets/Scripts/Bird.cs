using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Bird : MonoBehaviour {

    private Rigidbody2D myRigidbody; 
    [SerializeField] float upVelocity; 
    private CharacterController controller; 
    private PlayerInput playerInput; 
    private InputAction moveAction; 

    private void Awake() {
        controller = this.gameObject.GetComponent<CharacterController>(); 
        playerInput = this.gameObject.GetComponent<PlayerInput>(); 

        moveAction = playerInput.actions["Fire"]; 

        myRigidbody = this.gameObject.GetComponent<Rigidbody2D>(); 
    }

    private void OnEnable() {
        moveAction.performed += _ => Jump(); 
    }

    private void OnDisable() {
        moveAction.performed -= _ => Jump(); 
    }

    // Update is called once per frame
    void FixedUpdate() {
        // myRigidbody.velocity = Vector2.up * upVelocity; 
    }

    public void Jump() {
        myRigidbody.velocity = Vector2.up * upVelocity; 
    }
}
