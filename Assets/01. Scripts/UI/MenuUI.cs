using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : Popup_UI
{
    private readonly string info = "Info";
    private readonly string resume = "Resume";
    private readonly string title = "Title";

    protected override void Start()
    {
        base.Start();

        ButtonSelect(info).onClick.AddListener(Info);
        ButtonSelect(resume).onClick.AddListener(Resume);
        ButtonSelect(title).onClick.AddListener(Title);
    }

    public void Resume()
    {
        StartCoroutine(onClickSound());
        Time.timeScale = 1.0f;
        UIManager.Instance.Exit();
    }

    public void Title()
    {
        StartCoroutine(onClickSound());
        Time.timeScale = 1.0f;
        UIManager.Instance.Exit();
        SceneManager.LoadScene(0);
    }

    public void Info()
    {
        StartCoroutine(onClickSound());
        UIManager.Instance.PopUp<InfoUI>();
    }
}
