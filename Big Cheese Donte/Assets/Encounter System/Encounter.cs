using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
	public CapsuleCollider player;
	public string area;
	public bool encounter;
	public float timer;
	public float maxtimer = 10f;
	private bool done;
	public int chance = 1;
	public Transition transition;

    private void Awake()
    {
		transition = gameObject.GetComponent<Transition>();
    }
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
			done = true;
		}
		
		
		
		
	}

	private void OnTriggerStay(Collider Zone)
	{
		if (Zone.CompareTag("Encounter") && done)
		{
			if (chance > Random.Range(0, 26))
            {
				print("gothja");
				transition.transition = true;
            }
			else
            {
				Timer();
            }
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
	

