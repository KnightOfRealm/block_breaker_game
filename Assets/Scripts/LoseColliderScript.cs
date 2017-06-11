using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColliderScript : MonoBehaviour {

	private LevelManagerScript levelManager;
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManagerScript> ();
	}
	void OnTriggerEnter2D(Collider2D trigger){
		print ("trigger");
		levelManager.LoadLevel ("Lose");
	}

	void OnCollisionEnter2D(Collision2D trigger){
		print ("collision");
	}
}
