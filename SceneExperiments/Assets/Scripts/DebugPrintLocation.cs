using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPrintLocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = this.transform.position;
        Debug.Log("The gameobject is at location " + pos.ToString());
	}
}
