using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    private Button[] buttons;
    private Dictionary<string, Button> buttonDict = new Dictionary<string, Button>();

    protected virtual void Start()
    {
        RegisterButton();
        Init();
    }

    protected abstract void Init();

    private void RegisterButton()
    {
        buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            buttonDict.Add(button.name, button);
            //Debug.Log(button.name);
        }
    }

    protected Button ButtonSelect(string name)
    {
        Button getBtn;

        if (buttonDict.TryGetValue(name, out getBtn))
        {
            return getBtn;
        }

        Debug.LogError("There is no Button name!");

        return null;
    }

}