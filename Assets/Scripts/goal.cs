using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {

	public GameObject GoalText; //floating text on top of the goal
	public UIManager uimanager;
    public Score score;

	// Use this for initialization
	void Start () {
        //GameObject par = GameObject.FindGameObjectWithTag("Player");
		GoalText.GetComponent<MeshRenderer>().enabled = false;
	}

	void Update() {
		if(SceneManager.GetActiveScene ().name.CompareTo("UI") > 0) { //check that this is Level 1
			GoalText.GetComponent <MeshRenderer>().enabled = true;
		}
	}

    void OnTriggerEnter(Collider col)
    {

        //print("HIT");
        if (col.gameObject.CompareTag("Player"))
        {
            //goal reached
            //print("GOALLL");
            //text.text = "HIT";
            score.addPoints();
            uimanager.youWin = true; //turns on YouWin text
        }
    }
	
}
