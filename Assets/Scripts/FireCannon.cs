using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour {
	public Rigidbody cannonBall;
	public float speed = 10;
	// Update is called once per frame
	void Update() {
		if(Input.GetButtonDown("Fire2")) {
			Vector3 direction = GetComponent<Camera>().ScreenToWorldPoint(
				Input.mousePosition + Vector3.forward) - transform.position;
			direction.Normalize();
			Ray ray = new Ray (transform.position, direction);
			RaycastHit hitInfo;
			Physics.Raycast(ray, out hitInfo, GetComponent<Camera>().farClipPlane);
			if(hitInfo.collider != null &&
				hitInfo.collider.tag == "Brick") {
				GameObject obj = Instantiate(cannonBall.gameObject, // object to â€œcloneâ€
					transform.position, // starting position
					cannonBall.transform.rotation)// starting orientation
					as GameObject; // consider this instance as a GameObject
				// Give a starting velocity. transform.forward gives the direction where
				// this object (camera) is facing
				obj.GetComponent<Rigidbody>().velocity = direction * speed;
			}
		}
	}
}
