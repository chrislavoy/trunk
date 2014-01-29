using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour {
	public Rigidbody cannonBall;
	public float speed = 10;
	// Update is called once per frame
	void Update() {
		transform.position += 
			transform.forward * Input.GetAxis("Forward");
		transform.position += 
			transform.right * Input.GetAxis("Sideways");
		transform.Rotate(-Input.GetAxis("Vertical"),
				Input.GetAxis("Horizontal"), 0);
		if(Input.GetButtonDown("Fire1")) {
			GameObject obj = Instantiate(cannonBall.gameObject, // object to “clone”
				transform.position, // starting position
				cannonBall.transform.rotation)// starting orientation
				as GameObject; // consider this instance as a GameObject
			// Give a starting velocity. transform.forward gives the direction where
			// this object (camera) is facing
			obj.rigidbody.velocity = transform.forward * speed;
		}
	}
}
