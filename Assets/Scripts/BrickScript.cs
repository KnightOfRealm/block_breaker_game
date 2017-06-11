using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
	public AudioClip crackSound;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	private int maxHit;
	private int timesHit;
	public GameObject smoke;
	private LevelManagerScript levelManager;
	// Use this for initialization
	void Start () {
		if (this.tag == "Breakable") {
			breakableCount++;
			print ("breakable " + breakableCount);
		}
		maxHit = hitSprites.Length + 1;
		levelManager = GameObject.FindObjectOfType<LevelManagerScript> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable)
			HandleHits ();
	}

	void HandleHits(){
		timesHit++;
		AudioSource.PlayClipAtPoint (crackSound, transform.position);
		if (timesHit >= maxHit) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			print ("breakable " + breakableCount);
			GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
		} else {
			LoadSprite ();
		}
	}

	void LoadSprite(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void SimulateWin(){
		levelManager.LoadNextLevel ();
	} 
}
