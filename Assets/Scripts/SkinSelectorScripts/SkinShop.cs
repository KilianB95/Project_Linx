using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinShop : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject skinShopUI;

    public string _interactText()
    {
        return "Change Skin";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        OpenSkinMenu();
    }

    private void OpenSkinMenu()
    {
        Debug.Log("Opened Skin Menu");
        skinShopUI.SetActive(true);
    }
}
