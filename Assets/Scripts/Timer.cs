using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public UIManager uimanager;
    //public board ar;
    //DefaultTrackableEventHandler dteh;
    GameObject board;
    bool boardVisible = false;
	float timeStart = 0f;
	public Text timer;
	// Use this for initialization
	void Start () {
        board = GameObject.FindGameObjectWithTag("EditorOnly");
        //bool boardVisible = board.GetComponent("DefaultTrackableEventHandler").boardVisible;
        //DefaultTrackableEventHandler dteh = board.GetComponent(typeof(DefaultTrackableEventHandler)) as DefaultTrackableEventHandler;
		timer.text = ((int)timeStart).ToString ();
	}
	
	// Update is called once per frame
	void Update () {

        //boardVisible = board.GetComponentsInChildren<Renderer>().enabl;
        //boardVisible = dteh.boardVisible;
        /*print("IS it visible:" + boardVisible);
        if (boardVisible)
        {
            //time go
            timeStart += Time.deltaTime;
        }
        else
        {
            //do nothing
        } */
        timeStart += Time.deltaTime;
        timer.text = ((int)timeStart).ToString ();
        /*
		if(timeStart < 0) {
			uimanager.LoadLevel ("GameOver");
		} */
	}
}
