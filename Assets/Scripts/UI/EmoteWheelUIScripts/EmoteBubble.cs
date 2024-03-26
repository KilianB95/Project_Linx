using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteBubble : MonoBehaviour
{
    [SerializeField] private GameObject _emoteObject;
    [SerializeField] private Image _emoteSprite;
    [SerializeField] private float _emoteDuration;
    private float _emoteTimeLeft;
    private bool _emoteActive;

    private void Awake()
    {
        _emoteObject = GameObject.Find("EmoteBubble");
        _emoteSprite = GameObject.Find("PlayerEmote").GetComponent<Image>();
        _emoteObject.SetActive(false);
    }

    private void Update()
    {
        _emoteTimeLeft = _emoteActive ? _emoteTimeLeft + Time.deltaTime : 0; //Als emote actief is, tel timer op

        if (_emoteActive && _emoteTimeLeft > _emoteDuration)
        {
            _emoteObject.SetActive(false);
            _emoteActive = false;
        }

    }

    public void SetSprite(Sprite tempSprite)
    {
        _emoteSprite.sprite = tempSprite;
        _emoteObject.SetActive(true);
        _emoteActive = true;
    }
}
