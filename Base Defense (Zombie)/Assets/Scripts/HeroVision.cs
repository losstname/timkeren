using UnityEngine;
using System.Collections;

public class HeroVision : MonoBehaviour {
	public HeroVision instance = null;

	public GameObject heroObject;
	GameObject closestObject;
	public float distanceToDestroy = Mathf.Infinity;
	
	
	//other variables here for other functionality in this script
	
	void Start()
	{
		heroObject = GameObject.Find("Hero1");
		
		//edit this variable if you want specific distances 
		//before performing logic (after finding closest)
		distanceToDestroy = 50; 
		
		//I have other code here for functionality in this script
		
	}

	//finds closest object and returns it to destroyCLosestObject
	GameObject findClosestVisibility()
	{
		GameObject[]objectArray;
		objectArray = GameObject.FindGameObjectsWithTag("Enemy");
		
		float distance = Mathf.Infinity;
		
		Vector3 position = heroObject.transform.position;
		
		foreach(GameObject currentObject in objectArray)
		{
			Vector3 distanceCheck = currentObject.transform.position - position;    
			float currentDistance = distanceCheck.sqrMagnitude;
			
			if (currentDistance < distance)
			{
				closestObject = currentObject;
				
				distance = currentDistance;
				
			}
		}
		
		return closestObject;
	}
	
	
	//call this function to find the closest object
	//in this example it destroys it but it's not necessary to do so
	public void destroyClosestObject()
	{
		findClosestVisibility();
		
		
		
		//if you want additional logic checks do them here
		//if not skip this and destroy
		float finalDistanceCheck = Vector3.Distance (heroObject.transform.position, closestObject.transform.position);
		
		if (finalDistanceCheck <= distanceToDestroy)
		{
			//xxx;
		}
	}
	
}		