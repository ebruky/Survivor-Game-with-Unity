using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	public GameObject kalp;
	private Transform hedef;
	private int zombidenGelenPuan=10;
	private int zombiCan = 3;
	private float mesafe;
	private OyunKontrol oKontrol;
	private AudioSource aSource;
	private bool zombiOluyor = false;
	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
		oKontrol = GameObject.Find ("_Scripts").GetComponent<OyunKontrol> ();
		hedef = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt (hedef);
		GetComponent<Rigidbody> ().AddForce (transform.forward * 6f, ForceMode.Acceleration);
		mesafe = Vector3.Distance (transform.position,hedef.position);
		if (mesafe < 10f) {
			if (!aSource.isPlaying)
				aSource.Play ();
			if(!zombiOluyor)
			GetComponentInChildren<Animation> ().Play ("Zombie_Attack_01");
		} else {
			if (aSource.isPlaying)
				aSource.Stop ();
		}
	}

	void OnCollisionEnter(Collision c){
	
		if (c.collider.gameObject.tag.Equals ("mermi")) {
			zombiCan--;
			if(zombiCan==0){
				zombiOluyor = true;
				oKontrol.PuanArtir (zombidenGelenPuan);
				Instantiate (kalp, transform.position, Quaternion.identity);
				GetComponentInChildren<Animation> ().Play ("Zombie_Death_01");
				Destroy (this.gameObject,1.667f);
			}
		}
	}
}
