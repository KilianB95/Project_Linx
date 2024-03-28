using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 150, 0) * Time.deltaTime, Space.Self);
    }
}
