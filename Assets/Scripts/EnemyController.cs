using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start()
    {
        
    }


    private void Update()
    {
        transform.position = new Vector3(4, Mathf.Sin(Time.time), 4); 
    }
}
