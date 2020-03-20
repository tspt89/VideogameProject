using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_BearTrap : MonoBehaviour
{
	void OnTriggerStay2D (Collider2D thing)
	{
		if (thing.gameObject.tag == "Player") 
		{
			if (thing.gameObject.GetComponent<Player>().isAlive == true) 
			{
				thing.gameObject.GetComponent<Player>().Energy = 0;
				GetComponent<Animator>().Play("Bear_Trap_activated");
			}
		}
	}
}
