using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = "Score: " + Controller.score;
	
	}
}
