using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public WaypointGraph graph;
	public GameObject player;
	public GameObject enemy;
	bool havePath = false;
	
	// Update is called once per frame
	void Update () {
		if(!havePath)
		{
			graph.SetupSearch(enemy.transform.position, player.transform.position);
			havePath = true;
		}
	}
}
