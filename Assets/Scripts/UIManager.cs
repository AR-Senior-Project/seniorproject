﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		hidePaused ();
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

	//hides objects with ShowOnPause tag
	public void hidePaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level) {
		SceneManager.LoadScene(level);
	}

	/*
	 * This doesn't work on Editor.
	 * To test it, make a Build.
	*/
	public void Quit() {
		Application.Quit();
	}
}