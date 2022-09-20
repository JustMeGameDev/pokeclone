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
	public float maxtimer = 10f;
	private bool done;
	public int chance = 1;
 
	
	private void OnTriggerExit()
	
	{
		
		
		encounter = false;
		print("safe");
		area = "";
		done = true;
			
		
	}
	
	private void OnTriggerEnter(Collider Zone)
	{
		
		
		if(Zone.CompareTag("Encounter"))
		{
			encounter = true;
			area = "Encounter";
			print("spawn chance");
		}
		
		else if (Zone.CompareTag("Encounter test"))
		{
			encounter = true;
			area = "Encounter test";
			print("spawn test");
		}
		
	}

	private void OnTriggerStay(Collider Zone)
	{
		if (Zone.CompareTag("Encounter") && done)
		{
			if (chance > Random.Range(0, 26))
            {
				print("gothja");
				SceneManager.LoadScene("encounter");
            }
			else
            {
				Timer();
            }
		}

		else if (Zone.CompareTag("Encounter test"))
		{
			SceneManager.LoadScene("encounter");
		}
	}
	
	private void Timer()
    {
		
		done = false;
		timer = maxtimer;
    }



	
	

	void Update()
	{
		
		if (!done)
		{
			if (timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				print("done");
				timer = 0;
				chance++;
				done = true;
			}
		}
	}

	

}
	

