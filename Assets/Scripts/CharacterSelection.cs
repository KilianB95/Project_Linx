using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    private int selectedSkin = 0;

    public void NextSkin() //Is gekoppeld aan een button die de volgende skin actief maakt, en de huidige skin inactief.
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin = (selectedSkin + 1) % skins.Length;
        skins[selectedSkin].SetActive(true);
    }

    public void PreviousSkin() //Is gekoppeld aan een button die de vorige skin actief maakt, en de huidige skin inactief.
    {
        skins[selectedSkin].SetActive(false);
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin += skins.Length;
        }
        skins[selectedSkin].SetActive(true);
    }
}
