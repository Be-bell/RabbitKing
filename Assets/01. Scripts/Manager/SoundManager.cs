using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    BG3,
    BG4
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get { return instance; } }
    static SoundManager instance;
    readonly string path = "Sound/";

    List<AudioSource> audioSources = new List<AudioSource>();
    Dictionary<EffectSoundTag, AudioClip> effectSoundMap = new Dictionary<EffectSoundTag, AudioClip>();
    SoundObject soundObject;
    AudioSource source;

    [Header("Volume")]
    [SerializeField] private float MaxBGMVolume = 0.2f;
    [SerializeField] private float MaxEffectVolume = 0.5f;
    private float BGMVolume = 1f;
    private float EffectVolume = 1f;

    public float BGM { get { return BGMVolume; } }
    public float EFFECT { get { return EffectVolume; } }

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
        soundObject = Resources.Load<SoundObject>(path + "SoundObject");

        for (int i = 0; i < System.Enum.GetValues(typeof(AudioSourceIndex)).Length; i++)
        {
            audioSources.Add(gameObject.AddComponent<AudioSource>());
        }

        for(int i=0; i<soundObject.effectSounds.Count; i++)
        {
            effectSoundMap.Add(soundObject.effectSounds[i].EffectTag, soundObject.effectSounds[i].Sound);
        }

        PlayBGM(BGMIndex.BG1);
        //Debug.Log("Set");

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

        source.volume = BGMVolume * MaxBGMVolume;
        source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void PlayEffectSound(EffectSoundTag tag)
    {
        source = audioSources[(int)AudioSourceIndex.EFFECT];

        if (!effectSoundMap.ContainsKey(tag) ||effectSoundMap[tag] == null) return;

        AudioClip clip = effectSoundMap[tag];

        source.volume = EffectVolume * MaxEffectVolume;
        source.PlayOneShot(clip);
    }

    public void SoundControl(ScrollIndex idx, float value)
    {
        if (idx == ScrollIndex.BGM)
        {
            BGMVolume = value;
            audioSources[(int)AudioSourceIndex.BGM].volume = BGMVolume * MaxBGMVolume;
        }
        else
        {
            EffectVolume = value;
            audioSources[(int)AudioSourceIndex.EFFECT].volume = EffectVolume * MaxEffectVolume;
            audioSources[(int)AudioSourceIndex.BUTTON].volume = EffectVolume * MaxEffectVolume;
        }
    }
}
