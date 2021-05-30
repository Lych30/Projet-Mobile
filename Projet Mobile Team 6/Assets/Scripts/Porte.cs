using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    private bool isUsed = false;
    private void OnMouseDown()
    {
        if (GameManager.StaticMaxKey > 0 && !isUsed)
        {
            GameManager.StaticMaxKey--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            GetComponent<Collider2D>().enabled = true;
            gameObject.layer = 3;
            AstarPath.active.Scan();
            isUsed = true;
        }
        
    }
}
