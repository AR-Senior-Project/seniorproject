using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public UIManager uimanager;
	float timeLeft = 30.0f;
	public Text timer;
	// Use this for initialization
	void Start () {
		timer.text = ((int)timeLeft).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timer.text = ((int)timeLeft).ToString ();
		if(timeLeft < 0) {
			uimanager.LoadLevel ("GameOver");
		}
	}
}
