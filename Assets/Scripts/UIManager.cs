using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
	GameObject[] winObjects;
	public Score score;
	public Timer timer;
	public bool youWin = false;
	public Text TotalScore;
	//int levelScore;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		winObjects = GameObject.FindGameObjectsWithTag ("ShowOnWin");
		hidePaused ();
		hideWin ();
	}
	
	// Update is called once per frame
	void Update () {
		//if player presses ESC
		if(Input.GetKeyDown (KeyCode.Escape)) {
			if(Time.timeScale == 1) { //check if time is running
				Time.timeScale = 0; //stop the time
				showPaused();
			} else if(Time.timeScale == 0) { //if time stopped
				Time.timeScale = 1; //make time run normally
				hidePaused ();
			}
		}
		if(youWin) {
			Time.timeScale = 0; //stop time
			showWin ();
		}
	}

	//Reloads the level
	public void Reload() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//Controls the pausing of the scene
	public void pauseControl() {
		if(Time.timeScale == 1) {
			Time.timeScale = 0;
			showPaused();
		} else if(Time.timeScale == 0) {
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive(true);
		}
	}

	//displays objects with ShowOnWin tag
	public void showWin() {
		foreach (GameObject g in winObjects) {
			g.SetActive (true);
		}
		TotalScore.text = "Total Score: " + score.totalScore.ToString () + " + " + score.levelScore.ToString ();
	}

	//hides objects with ShowOnPause tag
	public void hidePaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive(false);
		}
	}

	//hides objects with ShowOnWin tag
	public void hideWin() {
		foreach (GameObject g in winObjects) {
			g.SetActive (false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level) {
		Time.timeScale = 1;	//reset time to normal
		SceneManager.LoadScene(level);
	}

	//loads the next level
	public void LoadLevel(int level) {
		Time.timeScale = 1; //reset time to normal
		//score.addPoints ((int)timer.timeStart * );
		score.addPoints ();
		SceneManager.LoadScene (level);
	}

	/*
	 * This doesn't work on Editor.
	 * To test it, make a Build.
	*/
	public void Quit() {
		Time.timeScale = 1; //reset time to normal
		Application.Quit();
	}
}