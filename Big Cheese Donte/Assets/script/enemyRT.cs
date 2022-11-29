using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyRT : recruitment
{

    protected int procentToRecruit = 1;

    // tijderlijke inventorie
     List<object> BecomeTeammate = new List<object>();

    private void Start()
    {
        bribeChance = procentToRecruit * 100 / 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bribeChance == 100)
        {
            if (Gift)
            {
                BecomeTeammate.Add(BecomeTeammate);
            }
        }
    }
}
