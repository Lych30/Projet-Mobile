using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            var TouchPos = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(TouchPos.origin,TouchPos.direction,Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Trap"))
                {
                    hit.transform.GetComponent<TrapTest>().enabled = true;
                }
            }
        }
    }
}
