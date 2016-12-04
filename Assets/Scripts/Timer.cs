using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public UIManager uimanager;
    GameObject par;
    Renderer parRen;
    bool boardVisible = false;
	public float timeStart = 0f;
	public Text timer;
    bool timerStart = false;
	// Use this for initialization
	void Start () {
        par = GameObject.FindGameObjectWithTag("Player");
        parRen = par.GetComponent<Renderer>();
        par.SetActive(false);
		timer.text = ((int)timeStart).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
        //when player presses space, start timer and show particle
		if(Input.GetKeyDown(KeyCode.Space) || Input.touches.Length > 0)
        {
            boardVisible = parRen.enabled;
            print(boardVisible);
            //don't do anything if space has already been pressed or board is not visible
            if (!timerStart && boardVisible)
            {
                timerStart = true;
                //enable particle
                par.SetActive(true);
            }
        }
        if (timerStart)
        {

            timeStart += Time.deltaTime;
        }

        timer.text = ((int)timeStart).ToString();
    }
}
