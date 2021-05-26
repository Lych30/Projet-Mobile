using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHighlight : MonoBehaviour
{
    public Shader HighlightShader;
    public Shader defaultShader;
    public GameObject[] trapsList;
    public bool activate = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        trapsList = GameObject.FindGameObjectsWithTag("Trap");
    }

    public void Highlight()
    {
        if (!activate)
        {
            foreach (GameObject go in trapsList)
            {
                go.GetComponent<Renderer>().material.shader = HighlightShader;
            }
            activate = true;
        }
        else
        {
            foreach (GameObject go in trapsList)
            {
                go.GetComponent<Renderer>().material.shader = defaultShader;
                
            }
            activate = false;
        }
    }
}
