using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{
    public GameObject Debris;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    private const float GRIDSIZE = 3;
    private bool used;
    private void OnEnable()
    {
        used = false;
        rb = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = Shader.Find("Unlit/Transparent");
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (!used && !Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped)
        {
            StartCoroutine("tombe");
        }
    }

    IEnumerator tombe()
    {
        rend.material.shader = shaderDefault;
        rb.gravityScale = 1;
        yield return new WaitForSeconds(0.75f);
        rend.enabled = false;
        Instantiate(Debris, new Vector3(transform.position.x + GRIDSIZE, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x - GRIDSIZE, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y + GRIDSIZE), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y - GRIDSIZE), new Quaternion());
        coll2d.enabled = false;
        gameObject.layer = 3;
        Destroy(GetComponent<Rigidbody2D>());
        AstarPath.active.Scan();
    }
}
