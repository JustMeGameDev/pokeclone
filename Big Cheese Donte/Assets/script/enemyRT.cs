using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyRT : recruitment
{

    protected int procentToRecruit = 1;

    // tijderlijke inventorie
    

    private void Start()
    {
        bribeChance = procentToRecruit * 100 / 10;
        
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (bribeChance == 100)
        {
            if (Gift)
            {
               // teamMember.Add(GameObject.FindGameObjectWithTag("enemy"));
            }
        }
    }

   
}
