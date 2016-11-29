using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text score;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		
	}

	/**
	 * Check this function with physsics
	 * Score system?
	 */
	void OnTriggerEnter(Collider other) {
		//check some collisions
		//count += 50;
	}

	void SetScore() {
		score.text = "Score: " + count.ToString ();
	}
}
