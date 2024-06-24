using System.Collections.Generic;
using System.Linq;
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
    BG2
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

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);

        Init();

        PlayBGM(BGMIndex.BG1);

    }

    private void Init()
    {
        soundObject = AssetDatabase.LoadAssetAtPath<SoundObject>(path + "SoundObject.asset");

        for (int i = 0; i < System.Enum.GetValues(typeof(AudioSourceIndex)).Length; i++)
        {
            audioSources.Add(Util.GetOrAddComponent<AudioSource>(gameObject));
        }

        for(int i=0; i<soundObject.effectSounds.Count; i++)
        {
            effectSoundMap.Add(soundObject.effectSounds[i].EffectTag, soundObject.effectSounds[i].Sound);
        }
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

        AudioClip clip = null;
        switch(idx)
        {
            case BGMIndex.BG1:
                clip = soundObject.BGM1;
                break;
            case BGMIndex.BG2:
                clip = soundObject.BGM2;
                break;
        }

        if(clip == null)
        {
            Debug.Log("There is No Audio Clip.");
            return;
        }

        source.loop = true;
        source.clip = clip;
        source.volume = 0.1f;
        source.Play();
    }

    public void PlayEffectSound(EffectSoundTag tag)
    {
        source = audioSources[(int)AudioSourceIndex.EFFECT];

        if (!effectSoundMap.ContainsKey(tag) ||effectSoundMap[tag] == null) return;

        AudioClip clip = effectSoundMap[tag];

        source.PlayOneShot(clip);
    }
}
