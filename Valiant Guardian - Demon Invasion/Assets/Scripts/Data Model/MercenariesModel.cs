using UnityEngine;
using System.Collections;

public class MercenariesModel {
	private int hitPoints;
	private int level;

	public MercenariesModel (int level)
	{
		this.level = level;
		preparingData();
	}
	

	private void preparingData ()
	{
		hitPoints = 0;
		for(int x=0; x<level ; x++){
			//based on game design --> Merc’s HP per level : ((level^2) * 10) + Merc’s previous Max HP
			hitPoints = level * level * 10 + hitPoints;
		}
	}

	public int HitPoints {
		get {
			return this.hitPoints;
		}
		set {
			hitPoints = value;
		}
	}

	public int Level {
		get {
			return this.level;
		}
		set {
			level = value;
		}
	}
}
