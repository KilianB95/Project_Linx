using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinShop : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _skinShopUI;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor) //Zodra je op E drukt open het skin menu.
    {
        _skinShopUI.SetActive(true);
        Debug.Log("Skin Menu Open");
        return true;
    }

    public void closeSkinUI() //Deze functie is voor het sluiten van het skin menu doormiddel van een button.
    {
        _skinShopUI.SetActive(false);
    }
}
