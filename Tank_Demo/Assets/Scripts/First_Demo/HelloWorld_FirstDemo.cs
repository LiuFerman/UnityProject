using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld_FirstDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.Label(new Rect(100,100,100,200),"Hello World");
    }
}
