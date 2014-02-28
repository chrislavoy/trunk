using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	
	public GUISkin skin;
	
	void OnGUI() {
		GUI.skin = skin;
		
		if(GUI.Button(new Rect(50,50,200,40), "Play")){
			//Application.LoadLevel("Lab 5");
			Application.LoadLevel(Application.loadedLevel+1);
		}
		if(GUI.Button(new Rect(50,100,200,40), "Controls")){
		}
		if(GUI.Button(new Rect(50,150,200,40), "Quit"))
			Application.Quit ();
		
		Controller.name = 
			GUI.TextField(new Rect(50,200,200,40), Controller.name);
	}
}
