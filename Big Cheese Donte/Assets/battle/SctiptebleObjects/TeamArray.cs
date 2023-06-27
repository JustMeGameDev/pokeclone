using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Teammate", menuName = "TeamMembers")]
public class TeamArray : ScriptableObject
{
    public Enemy[] Array;
    public Enemy Standing;
}
