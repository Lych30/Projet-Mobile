using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    private bool isUsed = false;
    private SpriteRenderer rend;
    private Shader shaderDefault;

    private void Start()
    {
        shaderDefault = Shader.Find("Sprites/Default");
        rend = GetComponent<SpriteRenderer>();

    }
    private void OnMouseDown()
    {
        if (GameManager.StaticMaxKey > 0 && !isUsed)
        {
            GameManager.StaticMaxKey--;
            rend.material.shader = shaderDefault;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            GetComponent<Collider2D>().enabled = true;
            gameObject.layer = 3;
            AstarPath.active.Scan();
            isUsed = true;
        }
        
    }
}
