using UnityEngine;
using System.Collections.Generic;

public class WaypointGraph : MonoBehaviour {
	
	private List<Node> nodes;
	
	void Start () {
		// Create nodes
		nodes = new List<Node>();
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		for(int i = 0; i < waypoints.Length; i++)
		{
			Node node = new Node();
			node.position = waypoints[i].transform.position;
			nodes.Add(node);
			//Destroy(waypoints[i]);
		}
		// Find neighbors
		for(int i = 0; i < nodes.Count; i++)
			for(int j = i+1; j < nodes.Count; j++)
		{
			Vector3 dir = nodes[j].position - nodes[i].position;
			// if i-j can be connected, then
			if(!Physics.Raycast(
				new Ray(nodes[i].position,
				dir.normalized),
				dir.magnitude))
			{
				nodes[i].neighbors.Add (nodes[j]);
				nodes[j].neighbors.Add (nodes[i]);
			}
		}
		
		foreach(Node node in nodes)
		{
			print (node.neighbors.Count);
		}
		
	}
}
