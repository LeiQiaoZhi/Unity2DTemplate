using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

// SINGLETON

public class MessageManager : MonoBehaviour
{
    [SerializeField] private bool testMessages;
    [SerializeField] GameObject messageCanvasPrefab;
    [SerializeField] GameObject messageObjectPrefab;
    [SerializeField] GameObject popupObjectPrefab;

    public static MessageManager Instance;

    GameObject _messageCanvas;

    private void Start()
    {
        if (testMessages)
        {
            // test message
            DisplayMessage("Test Message", null, 2);

            // test popup
            var popup = DisplayPopup("TITLE", "test message");
            popup.AddButton("Confirm", null, () =>
            {
                XLogger.Log(Category.UI, "confirm button pressed");
                Destroy(gameObject);
            });
            popup.AddButton("Cancel", null, () =>
            {
                XLogger.Log(Category.UI, "cancel button pressed");
                Destroy(gameObject);
            });
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (_messageCanvas == null)
        {
            _messageCanvas = Instantiate(messageCanvasPrefab, transform);
        }
    }

    public void DisplayMessage(string text, Color? textColor = null, float? duration = null)
    {
        GameObject messageGo = Instantiate(messageObjectPrefab, _messageCanvas.transform);
        Message m = messageGo.GetComponent<Message>();
        m.Init(text, textColor, duration);
        Destroy(messageGo, 10f);
    }

    public Popup DisplayPopup(string title = "", string text = "", Color? titleColor = null)
    {
        GameObject messageGo = Instantiate(popupObjectPrefab, _messageCanvas.transform);
        Popup m = messageGo.GetComponent<Popup>();
        m.Init(title, text, titleColor);
        return m;
    }
}