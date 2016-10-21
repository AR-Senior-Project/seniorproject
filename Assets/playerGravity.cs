using UnityEngine;
using System.Collections;

public class playerGravity : MonoBehaviour {

	GameObject 		player;
	GameObject 		sink;
	GameObject[] 	sinks;
	float 	G;         	// Gravitational constant: use for scaling
	float 	M;          // Mass of sink: use for pull intensity
	Vector3 r;          // Radius vector between two objects
	float 	R;          // Magnitude of radius
	float 	a;          // Magnitude of acceleration
	Vector3 v;          // Velocity 
	Vector3 dv;         // Change in velocity
	float 	dt;        	// Time step

	// Use this for initialization
	void Start () {
		G = 0.1F;
		M = 100;
		dt = 0.1F;

		player = GameObject.FindWithTag("Player");
		sinks = GameObject.FindGameObjectsWithTag("Sink");
		sink = sinks [0];
		// Player starts with an initial velocity
		v = new Vector3(-1, 0, 1);
	}

	// Update is called once per frame
	void Update () {
		Vector3 A = new Vector3 (0, 0, 0);
		foreach (GameObject sink in sinks) {
			// radius between the two objects
			r = sink.transform.position - player.transform.position;
			// magnitude of radius
			R = r.magnitude;

			// magnitude of acceleration
			a = G * M / R / R;
			A += r / R * a;

			// change in velocity
			dv = dt * A;
			// velocity
			v += Vector3.Scale(dv, new Vector3(1,0,1));
		}

		// player's new position is the old position + the change in position
		player.transform.position += v*dt;
	}
}
