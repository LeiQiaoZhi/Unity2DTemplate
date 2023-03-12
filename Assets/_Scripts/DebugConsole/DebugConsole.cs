using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    public KeyCode consoleKey;
    public GameObject console;
    public TMP_InputField inputField;
    public RectTransform historyContainer;
    public GameObject historyTextPrefab;

    List<DebugCommand> _commandList;

    private void Awake()
    {
        console.SetActive(false);

        // stores all the available commands in a list
        _commandList = new List<DebugCommand>
        {
            DebugCommandList.TestCommand,
            DebugCommandList.QuitCommand,
            DebugCommandList.HelpCommand
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(consoleKey))
        {
            console.SetActive(!console.activeSelf);
            if (console.activeSelf)
            {
                inputField.Select();
            }
        }

        if (console.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnCommandEnter();
            }
        }
    }

    public void OnCommandEnter()
    {
        var inputText = inputField.text;
        if (inputText == "")
            return;
        HandleInput(inputText);
        
        // clear text
        inputField.text = "";
        // inputField.Select();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void HandleInput(string input)
    {
        bool valid = false;
        string result = "";
        // check if the input contains any valid commands
        for (int i = 0; i < _commandList.Count; i++)
        {
            if (input.Contains(_commandList[i].CommandName))
            {
                result = _commandList[i].Raise(this);
                valid = true;
                XLogger.Log(Category.DebugConsole, result);
                break;
            }
        }

        if (!valid)
        {
            result = $"Command \"{input}\" not found.";
            XLogger.LogWarning(Category.DebugConsole, result);
        }

        var history = Instantiate(historyTextPrefab, historyContainer);
        var tmp = history.GetComponent<TextMeshProUGUI>();
        tmp.text = result;
        tmp.color = valid ? Color.green : Color.yellow;
    }
}