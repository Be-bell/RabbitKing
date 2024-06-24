using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get { return instance; } }
    static SoundManager instance;
    readonly string path = "Assets/03. Prefabs/Sound/";

    AudioSource[] audioSources;
    SoundObject soundObject;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);

        audioSources = GetComponents<AudioSource>();
        soundObject = AssetDatabase.LoadAssetAtPath<SoundObject>(path + "SoundObject.asset");
    }

    public void PlayButton()
    {
        AudioSource button = audioSources[(int)AudioSourceIndex.BUTTON];

        if (soundObject.buttonSound == null)
        {
            Debug.Log("There is no Sound");
            return;
        }

        button.PlayOneShot(soundObject.buttonSound);
        
    }
}

//AudioSources Index
public enum AudioSourceIndex
{
    BUTTON,
    BG
}