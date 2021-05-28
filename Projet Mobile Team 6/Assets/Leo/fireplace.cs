using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireplace : MonoBehaviour
{
    public GameObject Flamme;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    private const float GRIDSIZE = 3;
    private bool used;
    private void Start()
    {
        used = false;
        coll2d = GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = Shader.Find("Unlit/Transparent");
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (!used && GameManager.StaticMaxTrap > 0)
        {
            used = true;
            rend.material.shader = shaderDefault;
            Instantiate(Flamme, new Vector3(transform.position.x, transform.position.y - GRIDSIZE), new Quaternion());
            Instantiate(Flamme, new Vector3(transform.position.x, transform.position.y - 2 * GRIDSIZE), new Quaternion());
            AstarPath.active.Scan();
            GameManager.StaticMaxTrap--;
        }
    }

}
