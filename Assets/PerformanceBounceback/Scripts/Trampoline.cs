using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript;
    public Rigidbody rigidbody;
    public bool ground;

	// Use this for initialization
	void Start () {
	    scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
	    pSystem = GetComponentInChildren<ParticleSystem>();
	    if (ground)
	    {
	        rigidbody = GetComponent<Rigidbody>();
	        rigidbody.Sleep();
        }
	    
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            scoreScript.score++;
            //Particle effect
            pSystem.Play();
        }

    }
}
