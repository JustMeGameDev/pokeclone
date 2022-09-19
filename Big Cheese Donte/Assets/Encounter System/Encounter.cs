using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Encounter : MonoBehaviour
{
	public CapsuleCollider player;
	public string area;
	public bool encounter;
	public float timer;
	private bool done;
 
	
	private void OnTriggerExit()
	
	{
		
		
		encounter = false;
		print("safe");
		area = "";
			
		
	}
	
	private void OnTriggerEnter(Collider Zone)
	{
		
		
		if(Zone.tag == "Encounter")
		{
			encounter = true;
			area = "Encounter";
			print("spawn chance");
		}
		
		else if (Zone.tag == "Encounter test")
		{
			encounter = true;
			area = "Encounter test";
			print("spawn test");
		}
		
	}

	private void OnTriggerStay(Collider Zone)
	{
		if (Zone.tag == "Encounter" && done)
		{
			Timer();
		}

		else if (Zone.tag == "Encounter test")
		{
			
		}
	}
	
	private void Timer()
    {
		
		done = false;
		for (float i = 10f; i < 20; i = +.1f) ;

    }
	
}
