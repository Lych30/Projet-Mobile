using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{
    public GameObject Debris;
    private void Start()
    {
        Instantiate(Debris, new Vector3(transform.position.x + 3, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x - 3, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y + 3), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y - 3), new Quaternion());
        gameObject.layer = 3;
        AstarPath.active.Scan();
    }
}
