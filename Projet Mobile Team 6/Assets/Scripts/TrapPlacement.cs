using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrapPlacement : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!AstarPath.active.GetNearest(transform.position).node.Walkable)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 255);
        }
    }
    private void OnMouseUp()
    {
        GraphNode node = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        transform.position = (Vector3)node.position;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        Camera.main.GetComponent<zoomPinch>().enabled = true;
    }
    private void OnMouseDown()
    {
        Camera.main.GetComponent<zoomPinch>().enabled = false;
    }
}
