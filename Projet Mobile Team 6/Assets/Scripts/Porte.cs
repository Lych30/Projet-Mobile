using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<Collider2D>().enabled = true;
        gameObject.layer = 3;
        AstarPath.active.Scan();
    }
}
