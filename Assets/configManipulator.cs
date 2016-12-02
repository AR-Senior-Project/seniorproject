using UnityEngine;
using System.Collections;

public class configManipulator : MonoBehaviour {

	public float intensity;		// value between 1-3 for now
	public bool isRepulsor;		// true if repulsor, false if sink
    public bool isOn = false;      //true if active on scene

	GameObject manipulator;		// this object

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
