using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SkinShop : MonoBehaviour, InterfaceInteraction
{
    [SerializeField] private string _prompt;

    public string _InteractionPrompt { get; }

    public bool Interact(Interactor _interactor)
    {
        Debug.Log("OpeningShop");
        SceneManager.LoadScene(1);
        return true;
    }

}
