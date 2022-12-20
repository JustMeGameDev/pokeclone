using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{ 
    //ZET DIT OP PLAYER
        
    private void OnTriggerEnter(Collider collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}