using UnityEngine;
using UnityEngine.UI;

public class AccesEmoteWheel : MonoBehaviour
{
    [SerializeField] private GameObject _emoteWheel;
    [SerializeField]private GameObject[] _emoteObjects;
    [SerializeField] private KeyCode _emoteWheelKeyCode;

    private void Awake()
    {
        for (int i = 0; i < _emoteObjects.Length; i++)
        {
            GameObject.Find("emote" + i);
        }
    }

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

        if(indexEmote >= 0 && indexEmote < _emoteObjects.Length)
        {
            _emoteObjects[indexEmote].SetActive(true);
            Debug.Log("clicked");
        }
    }

    public void OnEmoteButtonClick(int indexEmote) => TriggerEmote(indexEmote);

}
