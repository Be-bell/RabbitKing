using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject infoUI;

    Button[] buttons;
    Dictionary<string, Button> buttonDict = new Dictionary<string, Button>();

    private readonly string info = "Info";
    private readonly string resume = "Resume";
    private readonly string title = "Title";

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();

        foreach(Button button in buttons)
        {
            buttonDict.Add(button.name, button);
        }

        ButtonSelect(info).onClick.AddListener(Info);
        ButtonSelect(resume).onClick.AddListener(Resume);
        ButtonSelect(title).onClick.AddListener(Title);
    }

    private Button ButtonSelect(string name)
    {
        Button getBtn;
        if(buttonDict.TryGetValue(name, out getBtn))
        {
            return getBtn;
        }

        Debug.LogError("There is no Button name!");

        return null;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void Title()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Info()
    {
        infoUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
