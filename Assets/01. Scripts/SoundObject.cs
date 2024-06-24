using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundObject", menuName = "ScriptableObject/Sound", order = int.MaxValue)]
public class SoundObject : ScriptableObject
{
    [Header("Button Sound")]
    public AudioClip buttonSound;

    [Header("BackGround Music")]
    public AudioClip BGM1;
    public AudioClip BGM2;

    [Header("Effect Sounds")]
    public List<EffectSound> effectSounds;
}

[Serializable]
public class EffectSound
{
    public EffectSoundTag EffectTag;
    public AudioClip Sound;
}

public enum EffectSoundTag
{
    CHARGE,
    JUMP,
    LAND
}