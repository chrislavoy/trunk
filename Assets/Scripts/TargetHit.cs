using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			Destroy(collision.gameObject);
		gameObject.tag = "Brick";
		}
	}
}
