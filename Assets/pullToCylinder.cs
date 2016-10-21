using UnityEngine;
using System.Collections;

public class pullToCylinder : MonoBehaviour {

	GameObject player; 
	GameObject sink;
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
		M = 10;
		dt = 0.1F;

		player = GameObject.Find("Dynamic Sphere");
		sink = GameObject.Find("Static Cylinder");

		// Player starts with an initial velocity
		v = new Vector3(-1, 0, 1);
	}

	// Update is called once per frame
	void Update () {
		// get the radius between the two objects
		r = sink.transform.position - player.transform.position;
		R = r.magnitude;

		// Combine these equations to get magnitude of acceleration
		//   F = G * M * m / R / R;
		//   a = F / m;
		a = G * M / R / R;

		dv = r * a;
		v += Vector3.Scale(dv, new Vector3(1,0,1));

		player.transform.position += v*dt;
	}
}
