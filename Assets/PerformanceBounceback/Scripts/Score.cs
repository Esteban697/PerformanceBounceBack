using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameManager gameManager;
	
	// Update the score only when necessary
	public void UpdateScore () {
        Text text = GetComponentInChildren<Text>();
        text.text = "Score: " + gameManager.score.ToString();
	}
}
