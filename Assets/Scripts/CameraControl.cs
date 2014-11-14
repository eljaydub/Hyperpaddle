using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	[Range (0.05f,0.5f)] public float MotionFactor;
	private Vector3 moveTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			MotionFactor = Mathf.Clamp(MotionFactor+0.05f, 0.05f, 0.5f);
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			MotionFactor = Mathf.Clamp(MotionFactor-0.05f, 0.05f, 0.5f);
		}
	}
	
	public void ShiftAroundPaddle(Vector3 paddlePosition) {
		print("Camera Control: "+paddlePosition);
		moveTo.x = Mathf.Clamp(paddlePosition.x*MotionFactor, -10, 10);
		moveTo.y = Mathf.Clamp(paddlePosition.y*MotionFactor, -10, 10);
		moveTo.z = transform.position.z;
		transform.position = moveTo;
	}
}
