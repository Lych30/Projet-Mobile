using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{

    void Start()
    {
                var gg = AstarPath.active.data.gridGraph;
                for (int z = 0; z < gg.depth; z++)
                {
                    for (int x = 0; x < gg.width; x++)
                    {
                        var node = gg.GetNode(x, z);
                        var node2 = AstarPath.active.maxNearestNodeDistance;
                        Debug.Log(node.Penalty);
                        Debug.Log(node2);
                    }
                }
    }
   

   
}
