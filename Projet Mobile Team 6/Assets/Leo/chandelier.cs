using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{
    public GameObject Debris;
    private void Start()
    {
        StartCoroutine("tombe");
        
    }
    IEnumerator tombe()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(0.75f);
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(Debris, new Vector3(transform.position.x + 3, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x - 3, transform.position.y), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y + 3), new Quaternion());
        Instantiate(Debris, new Vector3(transform.position.x, transform.position.y - 3), new Quaternion());
        GetComponent<BoxCollider2D>().enabled=false;
        Destroy(GetComponent<Rigidbody2D>());
        gameObject.layer = 3;
        AstarPath.active.Scan();
    }
}
