using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrapTest : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("Activation");
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private void OnMouseUp()
    {
        GraphNode node = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        transform.position = (Vector3)node.position;
    }
}
