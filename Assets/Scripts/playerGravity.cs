using UnityEngine;
using System.Collections;

public class playerGravity : MonoBehaviour {

	GameObject 		player;
	//GameObject 		sink;
	GameObject[] 	manipulators;
	float 	G;         	// Gravitational constant: use for scaling
	float 	M;          // Mass of sink: use for pull intensity
	Vector3 r;          // Radius vector between two objects
	float 	R;          // Magnitude of radius
	float 	a;          // Magnitude of acceleration
	Vector3 v;          // Velocity 
	Vector3 dv;         // Change in velocity
	float 	dt;        	// Time step

	public float intensity; 	// determines how serious it pulls

	// Use this for initialization
	void Start () {
		G = 0.1F;
		dt = 0.1F;
		if (intensity != 0)
			G = intensity/100;
		
		player = GameObject.FindWithTag("Player");
		manipulators = GameObject.FindGameObjectsWithTag("Manipulator");
		//sink = sinks [0];
		// Player starts with an initial velocity
		v = new Vector3(0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		Vector3 A = new Vector3 (0, 0, 0);
		foreach (GameObject manipulator in manipulators) {

			M = manipulator.GetComponent<configManipulator> ().intensity;
			if (manipulator.GetComponent<configManipulator> ().isRepulsor) {
				M *= -1;
			}
			// radius between the two objects
			r = manipulator.transform.position - player.transform.position;
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

	void OnCollisionEnter (Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			// mirror velocity vector over contact.normal
			Vector3 n;
			n = Vector3.Normalize(contact.normal); 
			v = v - 2 * Vector3.Dot(v, n) * n;
		}
	}
}
