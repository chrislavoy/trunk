using UnityEngine;
using System.Linq;
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
			node.waypoint = waypoints[i];
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
		
	}
	
	public void SetupSearch(Vector3 enemyPosition, Vector3 playerPosition)
	{
		Node start = null, end = null;
		float startDistance = float.MaxValue;
		float endDistance = float.MaxValue;
		foreach(Node node in nodes)
		{
			if ((node.position - playerPosition).magnitude < startDistance)
			{
				start = node;
				startDistance = (node.position - playerPosition).magnitude;
			}
			
			if ((node.position - enemyPosition).magnitude < endDistance)
			{
				end = node;
				endDistance = (node.position - enemyPosition).magnitude;
			}
		}
		FindPath (start, end);
		Node current = end;
		while(current != null)
		{
			current.waypoint.renderer.material.color = Color.green;
			current = current.parent;
			
		}
	}
	
	void FindPath(Node start, Node end)
	{
		foreach(Node node in nodes)
		{
			node.Reset();
		}
		SortedList<float, List<Node>> openList = new SortedList<float, List<Node>>();
		start.cost = 0;
		start.status = Node.NodeStatus.Open;
		AddNode(openList, start);
		
		while(openList.Count > 0)
		{
			Node current = openList.ElementAt(0).Value[0];
			current.status = Node.NodeStatus.Closed;
			RemoveNode(openList, current);
			if(current == end)
				break;
			foreach(Node node in current.neighbors)
			{
				if(node.status == Node.NodeStatus.Closed)
					continue;
				float tempCost = current.cost + (current.position - node.position).magnitude;
				if(tempCost < node.cost)
				{
					if(node.status == Node.NodeStatus.Open)
						RemoveNode (openList,node);
					node.cost = tempCost;
					node.parent = current;
					AddNode (openList,node);
					current.status = Node.NodeStatus.Open;
				}
			}
			
		}
	}
	
	void AddNode(SortedList<float, List<Node>> openList, Node node)
	{
		if(openList.ContainsKey(node.cost))
			openList[node.cost].Add(node);
		else
		{
			openList[node.cost] = new List<Node>();
			openList[node.cost].Add(node);
		}
	}
	
	void RemoveNode(SortedList<float, List<Node>> openList, Node node)
	{
		if(openList.ContainsKey(node.cost))
		{
			openList[node.cost].Remove(node);
			if(openList[node.cost].Count == 0)
				openList.Remove(node.cost);
		}
	}
}
