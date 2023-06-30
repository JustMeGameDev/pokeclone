using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectscript : MonoBehaviour
{
    public GameObject Lasthit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    public float GroteDrawgizmo = 0.2f;
    public int MaxLenght = 100;
    public Transition transition;
    public bool fought;
    public BattleSystem battle;


    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxLenght) &&!fought)
        {

            Lasthit = hit.transform.gameObject;
            transition = Lasthit.GetComponent<Transition>();
            collision = hit.point;
            transition.transition = true;
            battle.RandomEnemy();
            this.GetComponent<detectscript>().enabled = false;
 
               
            
            print(hit.transform.gameObject);
        }

      

    }

   


}
