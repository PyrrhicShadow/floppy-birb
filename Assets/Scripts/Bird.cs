using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Bird : MonoBehaviour {

    [SerializeField] Rigidbody2D rb; 
    [SerializeField] Collider2D col; 
    [SerializeField] float upVelocity; 
    [SerializeField] float birdScale; 
    [SerializeField] PlayerInput playerInput; 
    private GameManager manager; 
    private InputAction moveAction; 

    private void Awake() {
        moveAction = playerInput.actions["Fire"]; 
    }

    void Start() {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); 
        transform.localScale = Vector3.one * birdScale; 
        moveAction.Disable(); 
    }

    public void Begin() {
        moveAction.Enable(); 
        col.enabled = true; 
        rb.WakeUp(); 
    }

    private void OnEnable() {
        moveAction.performed += _ => Jump(); 

    }

    private void OnDisable() {
        moveAction.performed -= _ => Jump(); 
    }

    public void Jump() {
        if (rb != null) {
            rb.velocity = Vector2.up * upVelocity; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            manager.GameOver(); 
            KillBird(); 
        }
    }

    public void KillBird() {
        // this.gameObject.SetActive(false); 
        transform.localScale = new Vector3(birdScale, -1 * birdScale, birdScale); 
        moveAction.Disable(); 
        col.enabled = false; 
    }
}
