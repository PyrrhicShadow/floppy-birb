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
    private Animator animator; 

    private void Awake() {
        moveAction = playerInput.actions["Fire"]; 
    }

    void Start() {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); 
        animator = this.gameObject.GetComponent<Animator>(); 
        transform.localScale = Vector3.one * birdScale; 
        // moveAction.Disable(); 
    }

    void Update() {
        if (this.transform.position.y < -10) {
            rb.Sleep(); 
        }
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
            // animator.SetTrigger("flap"); 
            StartCoroutine(FlapCo()); 
        }
    }

    private IEnumerator FlapCo() { 
        animator.SetBool("flap", true);
        for (int i = 0; i < 5; i++) {
            yield return new WaitForFixedUpdate(); 
        }
        animator.SetBool("flap", false); 
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
        // col.enabled = false; 
    }
}
