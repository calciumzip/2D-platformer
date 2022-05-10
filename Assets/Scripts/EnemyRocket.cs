using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyrocket : MonoBehaviour
{
    public AIPath aiPath;


   
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localscale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localscale = new Vector3(1f, 1f, 1f);
        }
    }
}
