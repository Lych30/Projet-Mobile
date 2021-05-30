using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{

    public GameObject Debris;
    public GameObject TriggerZone;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    private const float GRIDSIZE = 3;
    private bool used;

    private void Start()
    {
        used = false;
        rb = GetComponent<Rigidbody2D>();
        coll2d = TriggerZone.GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = Shader.Find("Unlit/Transparent");
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (coll2d != null && herocoll2d != null)
        {
            if (!used && !Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped && GameManager.StaticMaxTrap > 0)
            {
                StartCoroutine("tombe");
                GameManager.StaticMaxTrap--;
            }
        }
    }

    IEnumerator tombe()
    {
        rend.material.shader = shaderDefault;
        rb.gravityScale = 1;
        yield return new WaitForSeconds(1.63f);
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
