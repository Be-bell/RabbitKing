using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_UI : MonoBehaviour
{
    private Button[] buttons;
    private Dictionary<string, Button> buttonDict = new Dictionary<string, Button>();

    protected virtual void Start()
    {
        RegisterButton();
    }

    private void RegisterButton()
    {
        buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            buttonDict.Add(button.name, button);
        }

        if(buttonDict.ContainsKey("Exit"))
        {
            ButtonSelect("Exit").onClick.AddListener(UIManager.Instance.Exit);
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