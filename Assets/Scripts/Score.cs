using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	//public int score; //this is the level's score
	public int totalScore;
	public Text text;

	// Use this for initialization
	void Start () {
		//Reset the totalScore when Level 1 is loaded
		if(SceneManager.GetActiveScene ().name.CompareTo ("Level 1") > 0) { //strings are the same
			totalScore = 0;
			PlayerPrefs.SetInt ("totalScore", totalScore);
		}
		totalScore = PlayerPrefs.GetInt ("totalScore", totalScore);
		//score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//text.text = totalScore.ToString ();
	}

	/*
	 * This will be called before switching to the next level
	 */
	public void addPoints(int points) {
		totalScore += points;
		PlayerPrefs.SetInt ("totalScore", totalScore);
	}
}
