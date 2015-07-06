using UnityEngine;
using System.Collections;
[System.Serializable]
public class Testing
{
	public string name {get;set;}
	public int identity {get;set;}


	public Testing (string name, int identity)
	{
		this.name = name;
		this.identity = identity;
	}
	
}

