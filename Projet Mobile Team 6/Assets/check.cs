using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class check : MonoBehaviour
{
    private Transform[] attaches;
    AIPath path;
    void Start()
    {
        var gg = AstarPath.active.data.gridGraph;
        path = GetComponent<AIPath>();
        for (int z = 0; z < gg.depth; z++)
        {
            for (int x = 0; x < gg.width; x++)
            {
               
            }
        }
        Debug.Log(path.velocity);
    }
   
}
