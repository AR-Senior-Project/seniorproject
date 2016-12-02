using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	//public int score; //this is the level's score
	public int totalScore;
	public Text text;
    public Timer timer;
    int time;

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
	public void addPoints() {
        int points = 0;
        time = (int)timer.timeStart;
        //get full points if done within 5 sec, otherwise lose points per sec
        if(time < 5)
        {
            points = 100;
        }
        else
        {
            points = 100 - (time - 5);
        }
        //if negative score, award 0 points
        if (points < 0) {
            points = 0;
        }
        totalScore += points;
		PlayerPrefs.SetInt ("totalScore", totalScore);
        print("points: " + points);
        print("total: " + totalScore);
	}
}
