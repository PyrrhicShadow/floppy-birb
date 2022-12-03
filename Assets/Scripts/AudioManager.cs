using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    [SerializeField] AudioSource background; 
    [SerializeField] AudioSource score; 

    // Start is called before the first frame update
    void Start()
    {
        background.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score() {
        score.Play(); 
    }
}
