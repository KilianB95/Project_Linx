using UnityEngine;

public class AccesEmoteWheel : MonoBehaviour
{
    [SerializeField] private GameObject _emoteWheel;
    private GameObject[] _emoteObjects;
    private Transform _transform;
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

    private void TriggerEmote(int indexEmote)
    {
        foreach (GameObject _emoteObject in _emoteObjects)
        {
            _emoteObject.SetActive(false);
        }

        if(indexEmote >= 0 && indexEmote < _emoteObjects.Length)
        {
            _emoteObjects[indexEmote].SetActive(true);
            _emoteObjects[indexEmote].transform.position = _transform.position + Vector3.up * 2f;
        }
    }

    private void OnEmoteButtonClick(int indexEmote) => TriggerEmote(indexEmote);

}
