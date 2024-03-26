using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEmote : MonoBehaviour
{
    [SerializeField] private Image _emoteSprite;

    private void Awake()
    {
        _emoteSprite = GetComponent<Image>();
    }

    public void SetSprite(Sprite tempSprite)
    {
        _emoteSprite.sprite = tempSprite;
    }
}
