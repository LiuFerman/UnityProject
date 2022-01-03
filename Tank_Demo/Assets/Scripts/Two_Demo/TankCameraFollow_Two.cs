using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCameraFollow_Two : MonoBehaviour
{
    public float distance = 2000;
    public float rot = 0;
    private float roll = 30f * Mathf.PI * 2 / 360;
    private float maxRoll = 70 * Mathf.PI * 2 / 360;
    private float minRoll = -10f * Mathf.PI * 2 / 360;
    private GameObject target;

    public float rotSpeed = 0.2f;
    private float rollSpeed = 0.2f;


    private float maxDistance = 3000;
    private float minDistance = 1000;
    private float zoomSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("tank");
        SetTarget(GameObject.Find("tank"));
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (target==null)
        {
            return;
        }
        if (Camera.main==null)
        {
            return;
        }
        Rotate();
        Roll();
        Zoom();
        Vector3 targetPos = target.transform.position;
        Vector3 cameraPos;
        float d = distance * Mathf.Cos(roll);
        float height = distance * Mathf.Sin(roll);
        cameraPos.x = targetPos.x + d * Mathf.Cos(rot);
        cameraPos.z = targetPos.z + d * Mathf.Sin(rot);
        cameraPos.y = targetPos.y + height;
        Camera.main.transform.position = cameraPos;


        Camera.main.transform.LookAt(target.transform);
        
    }
    public void SetTarget(GameObject _target)
    {
        if (_target.transform.Find("cameraPoint")!=null)
        {
            this.target = _target.transform.Find("cameraPoint").gameObject;
        }
        else
        {
            this.target = _target;
        }
    }
    void Rotate()
    {
        float w = Input.GetAxis("Mouse X") * rotSpeed;
        rot -= w;
    }
    void Roll()
    {
        float w= Input.GetAxis("Mouse Y") * rollSpeed*0.5f;
        roll -= w;
        if (roll>maxRoll)
        {
            roll = maxRoll;
        }
        else if(roll<minRoll)
        {
            roll = minRoll;
        }
    }
    void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") >0)
        {
            print(distance);
            if (distance>minDistance)
            {
                distance -= zoomSpeed;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (distance<maxDistance)
            {
                distance += zoomSpeed;
            }
        }
    }
}
