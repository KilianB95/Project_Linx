using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class QuickMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,10) * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-10,0,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,0,-10) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);
        }
    }
}
