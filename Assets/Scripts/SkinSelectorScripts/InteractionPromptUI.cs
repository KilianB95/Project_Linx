using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    public bool _isDisplayed = false;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;


    private void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }

    private void Update()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public void SetUp(string prompText)
    {
        _promptText.text = prompText;
        _uiPanel.SetActive(true);
        _isDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        _isDisplayed = false;
    }
}
