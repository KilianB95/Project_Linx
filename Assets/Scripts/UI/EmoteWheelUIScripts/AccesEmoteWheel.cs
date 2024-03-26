using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class EmoteButtonClicked : UnityEvent<Sprite>
{
}

public class AccesEmoteWheel : MonoBehaviour
{
    [SerializeField] private GameObject _emoteWheel;
    [SerializeField] private int _emoteAmount;
    [SerializeField] private KeyCode _emoteWheelKeyCode;
    [SerializeField] private EmoteButtonClicked _buttonEvent;
    private Button[] _emoteButtons;
    private Sprite[] _emoteSprites;

    private void Awake()
    {
        _emoteButtons = new Button[_emoteAmount];
        _emoteSprites = new Sprite[_emoteAmount];

        for (int i = 0; i < _emoteButtons.Length; i++)
        {
            _emoteButtons[i] = GameObject.Find("EmoteButton" + i).GetComponent<Button>();
            _emoteSprites[i] = GameObject.Find("Emote" + i).GetComponent<Image>().sprite;
            int index = i; //Nodig omdat anders een array index out of bounds error gegeven wordt
            _emoteButtons[i].onClick.AddListener(delegate { OnButtonClick(_emoteSprites[index]); });
        }

        _emoteWheel = GameObject.Find("EmoteCentre");
        _emoteWheel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_emoteWheelKeyCode))
            SetEmoteWheel(true);

        else if(Input.GetKeyUp(_emoteWheelKeyCode))
            SetEmoteWheel(false);
    }

    private void SetEmoteWheel(bool wheelStatus)
    {
        _emoteWheel.SetActive(wheelStatus);
    }

    private void OnButtonClick(Sprite emoteSprite)
    {
        _emoteWheel.SetActive(false);
        _buttonEvent.Invoke(emoteSprite);
    }

}
