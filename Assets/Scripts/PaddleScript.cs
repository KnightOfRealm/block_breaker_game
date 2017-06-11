using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
	float mousePositionInX = 8.0f;
	public bool isAutoPlay = false;
	private BallScript ball;

	void Start(){
		ball = GameObject.FindObjectOfType<BallScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (!isAutoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition= ball.transform.position;
		//print (mousePositionInX);
		paddlePos.x = Mathf.Clamp (ballPosition.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		mousePositionInX = Input.mousePosition.x / Screen.width * 16;
		//print (mousePositionInX);
		paddlePos.x = Mathf.Clamp (mousePositionInX, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
