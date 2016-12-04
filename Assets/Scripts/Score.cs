using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	//public int score; //this is the level's score
	public int totalScore;
	//public Text text;
    public Timer timer;
    int time;
	public int levelScore;

	// Use this for initialization
	void Start () {
		//Reset the totalScore when Level 0 is loaded
		if(SceneManager.GetActiveScene ().name.CompareTo ("Level 0") == 0) { //strings are the same
            //print("LEVEL 0");
			totalScore = 0;
			PlayerPrefs.SetInt ("totalScore", totalScore);
		}
		totalScore = PlayerPrefs.GetInt ("totalScore", totalScore);
        levelScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//text.text = totalScore.ToString ();
		/* To calculate the levelScore to display at the YouWin screen*/
		if((int)timer.timeStart < 5) {
			levelScore = 100;
		} else {
			levelScore = 100 - ((int)timer.timeStart - 5);
		}
		if(levelScore < 0) {
			levelScore = 0;
		}
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
		/* UIManager takes care of displaying this in the YouWin screen*/
	}
}
