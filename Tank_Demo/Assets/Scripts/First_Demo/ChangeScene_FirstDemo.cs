using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_FirstDemo : MonoBehaviour
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
        if (GUI.Button(new Rect(300,0,100,100),"切换"))
        {
            if (SceneManager.GetActiveScene().name.Equals("FirstDemo"))
            {
                SceneManager.LoadScene("Two");
            }
            else
            {
                SceneManager.LoadScene("FirstDemo");
            }
            
        }
    }
}
