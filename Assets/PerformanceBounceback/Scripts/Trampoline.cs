using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript;
    public Score scoreText1;
    public Score scoreText2;

    // Use this for initialization
    void Start () {
	    scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
	    pSystem = GetComponentInChildren<ParticleSystem>();
        scoreText1 = GameObject.Find("ScoreBoard (1)").GetComponent<Score>();
        scoreText2 = GameObject.Find("ScoreBoard (2)").GetComponent<Score>();
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
            //Update scoreboards
            scoreText1.UpdateScore();
            scoreText2.UpdateScore();
            //Particle effect
            pSystem.Play();
        }

    }
}
