using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text messageText;

    void Awake()
    {
        InteractionController interactionController = FindObjectOfType<InteractionController>();
        interactionController.changeMessageEvent += ChangeMessage;

        ChangeMessage(string.Empty);
    }

    private void ChangeMessage(string newMessage)
    {
        messageText.text = newMessage;
    }
}
