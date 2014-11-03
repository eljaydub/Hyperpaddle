using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public Camera myCamera;
	private float cameraToPaddleDistance;
	//Use this for initialization
	void Start () {
		cameraToPaddleDistance = transform.position.z - myCamera.transform.position.z;
	}
	
	void OnMouseDrag() {
		Vector3 mousePos = GetMouseCoordinatesAtDistance (cameraToPaddleDistance);
		MovePaddleTo (mousePos);
	}
	
	Vector3 GetMouseCoordinatesAtDistance (float worldUnitsFromCamera) {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 screenPos = new Vector3 (mouseX, mouseY, worldUnitsFromCamera);
		Vector3 worldPos = myCamera.ScreenToWorldPoint(screenPos);
		return worldPos;
	}
	
	void MovePaddleTo(Vector3 worldPos) {
		Vector3 moveTo;
		moveTo.x = Mathf.Clamp(worldPos.x, -7.5f, 7.5f);
		moveTo.y = Mathf.Clamp(worldPos.y, -7.5f, 7.5f);
		moveTo.z = transform.position.z;
		transform.position = moveTo;
	}
}
