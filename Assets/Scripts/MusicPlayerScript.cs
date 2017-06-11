using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour {
	static MusicPlayerScript instance = null;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else 
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
