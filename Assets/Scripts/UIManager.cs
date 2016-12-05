using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
	GameObject[] winObjects;
	public Score score;
	public Timer timer;
	public bool youWin = true;
	public Text TotalScore;
    bool paused = false;    //true if paused
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
		if(Input.GetKeyDown (KeyCode.Escape))
        {
            //check if paused
            if (paused)
            {
                paused = false;
                hidePaused();
            }
            else
            {
                paused = true;
                showPaused();
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
		TotalScore.text = "Level Score: " + score.levelScore.ToString () + "\nTotal Score: " + PlayerPrefs.GetInt ("totalScore").ToString ();
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
		//score.addPoints ();
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