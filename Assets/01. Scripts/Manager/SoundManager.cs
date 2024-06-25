using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//AudioSources Index
public enum AudioSourceIndex
{
    BGM,
    EFFECT,
    BUTTON
}

public enum BGMIndex
{
    BG1,
    BG2,
    BG3
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get { return instance; } }
    static SoundManager instance;
    readonly string path = "Assets/03. Prefabs/Sound/";

    List<AudioSource> audioSources = new List<AudioSource>();
    Dictionary<EffectSoundTag, AudioClip> effectSoundMap = new Dictionary<EffectSoundTag, AudioClip>();
    SoundObject soundObject;
    AudioSource source;

    private float BGMVolume = 1f;
    private float EFFECTVolume = 1f;

    public float BGM { get { return BGMVolume; } }
    public float EFFECT { get { return EFFECTVolume; } }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(instance);

        Init();
    }

    private void Init()
    {
        soundObject = AssetDatabase.LoadAssetAtPath<SoundObject>(path + "SoundObject.asset");

        for (int i = 0; i < System.Enum.GetValues(typeof(AudioSourceIndex)).Length; i++)
        {
            audioSources.Add(gameObject.AddComponent<AudioSource>());
        }

        for(int i=0; i<soundObject.effectSounds.Count; i++)
        {
            effectSoundMap.Add(soundObject.effectSounds[i].EffectTag, soundObject.effectSounds[i].Sound);
        }

        PlayBGM(BGMIndex.BG1);

        Debug.Log("Set");

    }

    public void PlayButton()
    {
        source = audioSources[(int)AudioSourceIndex.BUTTON];

        if (soundObject.buttonSound == null)
        {
            Debug.Log("There is no Sound");
            return;
        }

        source.PlayOneShot(soundObject.buttonSound);
        
    }

    public void PlayBGM(BGMIndex idx)
    {
        source = audioSources[(int) AudioSourceIndex.BGM];

        AudioClip clip = soundObject.BGM[(int) idx];

        if(clip == null)
        {
            Debug.Log("There is No Audio Clip.");
            return;
        }

        source.volume = BGMVolume;
        source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void PlayEffectSound(EffectSoundTag tag)
    {
        source = audioSources[(int)AudioSourceIndex.EFFECT];

        if (!effectSoundMap.ContainsKey(tag) ||effectSoundMap[tag] == null) return;

        AudioClip clip = effectSoundMap[tag];

        source.PlayOneShot(clip);
    }

    public void SoundControl(ScrollIndex idx, float value)
    {
        if (idx == ScrollIndex.BGM)
        {
            BGMVolume = value;
            audioSources[(int)AudioSourceIndex.BGM].volume = BGMVolume;
        }
        else
        {
            EFFECTVolume = value;
            audioSources[(int)AudioSourceIndex.EFFECT].volume = EFFECTVolume;
            audioSources[(int)AudioSourceIndex.BUTTON].volume = EFFECTVolume;
        }
    }
}
