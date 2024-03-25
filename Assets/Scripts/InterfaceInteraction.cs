using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceInteraction
{
    public string _InteractionPrompt { get; }
    public bool Interact(Interactor _interactor);
}
