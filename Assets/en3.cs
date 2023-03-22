using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class en3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(50, Mathf.Sin(Time.time), 50); 
    }
}
