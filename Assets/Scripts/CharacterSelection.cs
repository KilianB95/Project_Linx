using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _skins;
    private int _selectedSkin = 0;

    public void NextSkin() //Is gekoppeld aan een button die de volgende skin actief maakt, en de huidige skin inactief.
    {
        _skins[_selectedSkin].SetActive(false);
        _selectedSkin = (_selectedSkin + 1) % _skins.Length;
        _skins[_selectedSkin].SetActive(true);
    }

    public void PreviousSkin() //Is gekoppeld aan een button die de vorige skin actief maakt, en de huidige skin inactief.
    {
        _skins[_selectedSkin].SetActive(false);
        _selectedSkin--;
        if (_selectedSkin < 0)
        {
            _selectedSkin += _skins.Length;
        }
        _skins[_selectedSkin].SetActive(true);
    }

    public void SelectSkin()
    {
        PlayerPrefs.SetInt("selectedSkin", _selectedSkin);
        SceneManager.LoadScene(0);
    }
}
