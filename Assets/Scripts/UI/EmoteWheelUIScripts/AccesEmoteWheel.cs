using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesEmoteWheel : MonoBehaviour
{
    [SerializeField] private GameObject _emoteWheel;
    [SerializeField] private KeyCode _emoteWheelKeyCode;

    private void Update()
    {
        if (Input.GetKey(_emoteWheelKeyCode))
        {
            ShowEmoteWheel();
            Debug.Log("Wheel Shown");
        }
        else
        {
            HideEmoteWheel();
            Debug.Log("Wheel gone");
        }
    }

    private void ShowEmoteWheel()
    {
        _emoteWheel.SetActive(true);
    }

    private void HideEmoteWheel()
    {
        _emoteWheel.SetActive(false);
    }


}
