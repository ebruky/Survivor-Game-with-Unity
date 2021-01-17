using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KbZombi : MonoBehaviour {
	public Transform zombi;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (zombi.position.x, 100f, zombi.position.z);
		transform.rotation = Quaternion.Euler (zombi.eulerAngles.x+90f, zombi.eulerAngles.y, zombi.eulerAngles.z);
	}
}
