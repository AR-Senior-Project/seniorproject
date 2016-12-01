using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject par = GameObject.FindGameObjectWithTag("Player");
	}

    void OnTriggerEnter(Collider col)
    {

        print("HIT");
        if (col.gameObject.CompareTag("Player"))
        {
            //goal reached
            print("GOALLL");
        }
    }
	
}
