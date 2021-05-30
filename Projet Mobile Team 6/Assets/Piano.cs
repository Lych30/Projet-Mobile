using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Piano : MonoBehaviour
{
    public Transform Destination;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private AIDestinationSetter Ai;
    private const float GRIDSIZE = 3;
    private bool used;
    private void Start()
    {
        used = false;
        shaderDefault = Shader.Find("Unlit/Transparent");
        rend = GetComponent<SpriteRenderer>();
        Ai = GameObject.Find("Hero").GetComponent<AIDestinationSetter>();
    }


    private void OnMouseDown()
    {
        if (!used && GameManager.StaticMaxManifestation>0)
        {
            used = true;
            rend.material.shader = shaderDefault;
            Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x, transform.position.y -  2 *GRIDSIZE), new Quaternion()));
            GameManager.StaticMaxManifestation--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();
        }
    }
}
