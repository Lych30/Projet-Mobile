using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DestinationDestroyable : MonoBehaviour
{
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    // Start is called before the first frame update
    void Start()
    {
        coll2d = GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        Destroy(gameObject, 10);
    }

    void Update()
    {
        if (Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped)
        {
               Destroy(gameObject, 2);
        }
    }

    private void OnDestroy()
    {
        GameObject.Find("Hero").GetComponent<AIPath>().maxSpeed = 3;
    }
}
