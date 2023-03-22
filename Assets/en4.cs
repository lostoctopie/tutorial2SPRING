using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class en4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(57, Mathf.Sin(Time.time), 57); 
    }
}
