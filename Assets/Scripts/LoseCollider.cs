using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	public Ball ball;
	
	void OnTriggerEnter() {
		audio.Play();
		print ("Ball's z velocity "+ ball.rigidbody.velocity.z);
	}
}
