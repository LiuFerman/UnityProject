using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel_FirstDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string userName = "";
    public string password = "";

    void OnGUI()
    {
        GUI.Box(new Rect(210, 210, 200, 120), "登录框");
        GUI.Label(new Rect(220,240,50,30),"用户名");
        userName = GUI.TextField(new Rect(270, 240, 120, 20), userName);
        GUI.Label(new Rect(220,270,50,30),"密码");
        password = GUI.PasswordField(new Rect(270,270,120,20),password,'*');
        if (GUI.Button(new Rect(270, 300, 50, 25),"登录"))
        {
            if (userName == "hellolpy" && password == "123")
                Debug.Log("登录成功");
            else
                Debug.Log("登录失败");
        }
    }
}
