using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Test_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, Mathf.Sin (Time.time), transform.position.z);
		
	}
}
