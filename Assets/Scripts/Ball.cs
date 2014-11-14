using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 funnyBounce;

	public Vector3 velocity = new Vector3(10f, 20f, -40f);
	[Range(1F,1.1F)] public float speedMultiplier = 1.0f;
	
	// Use this for initialization
	void Start () {
		gameObject.rigidbody.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			speedMultiplier = Mathf.Clamp(speedMultiplier+0.01f, 1.0f, 1.1f);
		} else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			speedMultiplier = Mathf.Clamp(speedMultiplier-0.01f, 1.0f, 1.1f);
		}
	}
	
	void OnCollisionEnter() {
		audio.Play();
		Vector3 newVelocity;
		newVelocity.x = rigidbody.velocity.x;
		newVelocity.y = rigidbody.velocity.y;
		newVelocity.z = rigidbody.velocity.z * speedMultiplier;
		funnyBounce.x = Random.Range(-5f, 5f);
		funnyBounce.y = Random.Range(-5f, 5f);
		rigidbody.velocity = newVelocity + funnyBounce;
	}
}
