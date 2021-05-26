using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireplace : MonoBehaviour
{
    public GameObject Flame;
    private void Start()
    {
        Instantiate(Flame, new Vector3(transform.position.x + GetComponent<TrapTrigger>().scaleX, transform.position.y + GetComponent<TrapTrigger>().scaleY), new Quaternion());
        Instantiate(Flame, new Vector3(transform.position.x + 2 * GetComponent<TrapTrigger>().scaleX, transform.position.y + 2 * GetComponent<TrapTrigger>().scaleY), new Quaternion());
        AstarPath.active.Scan();
    }
}
