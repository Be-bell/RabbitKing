using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : Popup_UI
{
    private readonly string info = "Info";
    private readonly string resume = "Resume";
    private readonly string title = "Title";
    private readonly string sound = "Sound";

    protected override void Init()
    {
        ButtonSelect(info).onClick.AddListener(Info);
        ButtonSelect(resume).onClick.AddListener(Resume);
        ButtonSelect(title).onClick.AddListener(Title);
        ButtonSelect(sound).onClick.AddListener(Sound);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.Exit();
    }

    public void Title()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.Exit();
        SoundManager.Instance.PlayBGM(BGMIndex.BG1);
        SceneManager.LoadScene((int)Scene.START);
    }

    public void Info()
    {
        UIManager.Instance.PopUp<InfoUI>();
    }

    public void Sound()
    {
        UIManager.Instance.PopUp<SoundUI>();
    }
}
