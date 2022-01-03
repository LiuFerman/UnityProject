using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Two : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float speed = 1;
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.eulerAngles = new Vector3(0,0,0);
        //    transform.position += transform.forward * speed;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //    transform.position += transform.forward * speed;
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 270, 0);
        //    transform.position += transform.forward * speed;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 90, 0);
        //    transform.position += transform.forward * speed;
        //}
        float steer = 20f;
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(0,x*steer*Time.deltaTime,0);

        float speed = 150f;
        float y = Input.GetAxis("Vertical");
        Vector3 s = y * transform.forward * speed * Time.deltaTime;
        transform.position += s;
    }
}
