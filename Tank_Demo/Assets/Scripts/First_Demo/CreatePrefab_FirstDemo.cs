using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab_FirstDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
