using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    [SerializeField] GameObject pipe; 
    [SerializeField] float spawnRate; 
    [SerializeField] float heightOffset; 
    private float timer = 0; 

    // Start is called before the first frame update
    void Start() {
        SpawnPipe(); 
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime; 
        }
        else {
            SpawnPipe(); 
            timer = 0; 
        }
    }

    private void SpawnPipe() {
        float randHeight = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset); 

        GameObject nextPipe = Instantiate(pipe, new Vector3(transform.position.x, randHeight, 0), Quaternion.identity); 
        nextPipe.transform.parent = this.transform; 
    }
}
