using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer_FirstDemo : MonoBehaviour
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
        AudioSource audio = GetComponent<AudioSource>();
        if (GUI.Button(new Rect(0, 0, 100, 50), "开始"))
            audio.Play();
        if (GUI.Button(new Rect(100, 0, 100, 50), "停止"))
            audio.Stop();
    }
}
