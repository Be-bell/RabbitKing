using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : UI_Base
{
    private readonly string start = "Start";
    private readonly string quit = "Quit";
    private readonly string sound = "Sound";
    private readonly string info = "Info";

    [Header("Fadeout")]
    // Required Refactoring
    [SerializeField] private Image fadeoutPanel;
    [SerializeField] private float fadeoutTime = 2f;
    private float currentTime = 0f;
    

    protected override void Init()
    {
        fadeoutPanel.gameObject.SetActive(false);
        ButtonSelect(start).onClick.AddListener(() => StartCoroutine(StartGame()));
        ButtonSelect(quit).onClick.AddListener(QuitGame);
        ButtonSelect(sound).onClick.AddListener(Sound);
        ButtonSelect(info).onClick.AddListener(Info);
    }

    private IEnumerator StartGame()
    {
        fadeoutPanel.gameObject.SetActive(true);
        Color alpha = fadeoutPanel.color;

        while(alpha.a < 1)
        {
            currentTime += Time.deltaTime / fadeoutTime;
            alpha.a = Mathf.Lerp(0, 1, currentTime);
            fadeoutPanel.color = alpha;
            yield return null;
        }

        SoundManager.Instance.PlayBGM(BGMIndex.BG2);
        SceneManager.LoadScene((int) Scene.INTRO);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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

public enum Scene
{
    START,
    INTRO,
    GAME,
    END
}
