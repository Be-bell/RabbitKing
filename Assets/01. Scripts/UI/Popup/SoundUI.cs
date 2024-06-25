using UnityEngine.UI;

public enum ScrollIndex
{
    BGM,
    EFFECT
}


public class SoundUI : Popup_UI
{
    Slider[] sliders;

    protected override void Init()
    {
        sliders = GetComponentsInChildren<Slider>();

        sliders[(int)ScrollIndex.BGM].onValueChanged.AddListener(BGMControl);
        sliders[(int)ScrollIndex.EFFECT].onValueChanged.AddListener(EffectControl);

        sliders[(int)ScrollIndex.BGM].value = SoundManager.Instance.BGM;
        sliders[(int)ScrollIndex.EFFECT].value = SoundManager.Instance.EFFECT;
    }

    private void BGMControl(float arg)
    {
        SoundManager.Instance.SoundControl(ScrollIndex.BGM, arg);
    }

    private void EffectControl(float arg)
    {
        SoundManager.Instance.SoundControl(ScrollIndex.EFFECT, arg);
    }
}
