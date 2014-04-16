using UnityEngine;
using System.Collections.Generic;

public class Node
{
	public Vector3 position {get; set;}
	public List<Node> neighbors {get; protected set;}
	
	public Node()
	{
		position = Vector3.zero;
		neighbors = new List<Node>();
	}

}
