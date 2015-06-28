using UnityEngine;
using System.Collections;

public class CursorColorChange : MonoBehaviour {
	
	void OnMouseEnter() {
		GameObject.FindGameObjectWithTag("Cursor").
			GetComponent<GUITexture>().color = Color.green;
	}
	
	void OnMouseExit() {
		GameObject.FindGameObjectWithTag("Cursor").
			GetComponent<GUITexture>().color = Color.white;
	}
}
