using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour {
	public GameObject cannonBall;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(
			Input.GetAxis("Vertical"),
			Input.GetAxis("Horizontal"),0);
		if(Input.GetButtonDown("Fire1")){
			GameObject obj = Instantiate(
				cannonBall,
				transform.position,
				cannonBall.transform.rotation) as GameObject;
			obj.rigidbody.velocity = 
				transform.forward*speed;
		}
	}
}
