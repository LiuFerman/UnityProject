using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCameraFollow2_4 : MonoBehaviour
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

    //炮塔
    public Transform turret;
    //炮塔旋转速度
    public float turretRotSpeed = 0.5f;
    //炮塔目标角度
    private float turretRotTarget = 0;

    //炮管
    public Transform gun;
    //炮管的旋转范围
    private float maxRollGun = -40f;
    private float minRollGun = 4f;
    //炮管目标角度
    private float turretRollTarget = 0;
    // Start is called before the first frame update
    void Start()
    {
        turret = transform.Find("turret");
        gun = turret.Find("gun");
        //target = GameObject.Find("tank");
        SetTarget(GameObject.Find("tank"));

    }
    private void Update()
    {
        
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

        //炮塔角度
        turretRotTarget = Camera.main.transform.eulerAngles.y;
        //炮管角度
        turretRollTarget = Camera.main.transform.eulerAngles.x;
        //炮塔旋转
        TurretRotation();
        //炮管旋转
        TurretRoll();
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
    void TurretRotation()
    {
        if (Camera.main==null)
        {
            return;
        }
        if (turret==null)
        {
            return;
        }


        //归一化角度
        float angle = turret.eulerAngles.y - turretRotTarget;
        if (angle < 0) angle += 360;
        if (angle>turretRotSpeed&&angle<180)
        {
            turret.Rotate(0f,-turretRotSpeed,0f);
        }
        else if (angle>180&&angle<360-turretRotSpeed)
        {
            turret.Rotate(0f,turretRotSpeed,0f);
        }
    }
    //旋转炮管
    void TurretRoll()
    {
        if (Camera.main == null)
        {
            return;
        }
        if (turret == null)
        {
            return;
        }
        //获取角度
        Vector3 worldEuler = gun.eulerAngles;
        Vector3 localEuler = gun.localEulerAngles;
        //世界坐标系角度计算
        worldEuler.x = turretRollTarget;
        gun.eulerAngles = -worldEuler;
        //本地坐标系角度限制
        Vector3 euler = gun.localEulerAngles;
        if (euler.x>180)
        {
            euler.x -= 360;
        }
        if (euler.x>maxRollGun)
        {
            euler.x = maxRollGun;
        }
        else if (euler.x<minRollGun)
        {
            euler.x = minRollGun;
        }

        gun.localEulerAngles = new Vector3(euler.x,localEuler.y,localEuler.z);
    }
}
