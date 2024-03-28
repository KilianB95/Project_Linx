using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.x);
        Debug.Log(transform.rotation.eulerAngles.y);
        Debug.Log(transform.rotation.eulerAngles.z);
    }
}
