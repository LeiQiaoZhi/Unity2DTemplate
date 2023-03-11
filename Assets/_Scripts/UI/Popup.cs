using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Popup : MonoBehaviour
{
    [SerializeField] GameObject titlebar;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] Animator animator;

    [SerializeField] RectTransform buttonArea;
    [SerializeField] private GameObject buttonPrefab;


    private void Awake()
    {
    }

    public void Init(string title, string text, Color? titleColor)
    {
        if (title == "")
        {
            titlebar.SetActive(false);
        }
        else
        {
            titlebar.SetActive(true);
            titleText.text = title;
            titleText.color = titleColor.GetValueOrDefault(Color.white);
        }
        messageText.text = text;
    }

    public void AddButton(string text, Color? color, UnityAction callback)
    {
        var buttonObject = Instantiate(buttonPrefab, buttonArea);
        buttonObject.SetActive(true);
        buttonObject.GetComponent<Image>().color = color.GetValueOrDefault(Color.white);
        buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
        buttonObject.GetComponent<Button>().onClick.AddListener(callback);
    }
}