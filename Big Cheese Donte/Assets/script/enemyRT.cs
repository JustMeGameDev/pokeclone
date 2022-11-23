using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyRT : recruitment
{

    protected int procentToRecruit = 1;


    // Update is called once per frame
    void Update()
    {
        bribeChance = procentToRecruit * 100 / 10;

        if (procentToRecruit == 100)
        {
            
        }
    }
}
