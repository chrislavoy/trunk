using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public void ChangeColor() {
		GetComponent<Renderer>().material.color =
		new Color(Random.value, Random.value, Random.value, Random.value);
	}
}
