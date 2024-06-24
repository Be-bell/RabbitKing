using UnityEngine;

[CreateAssetMenu(fileName = "SoundObject", menuName = "ScriptableObject/Sound", order = int.MaxValue)]
public class SoundObject : ScriptableObject
{
    public AudioClip buttonSound;
    public AudioClip BGSound1;
    public AudioClip BGSound2;
}