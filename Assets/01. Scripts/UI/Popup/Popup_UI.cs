using UnityEngine.UI;

public class Popup_UI : UI_Base
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Init()
    {
        Button exitBtn = ButtonSelect("Exit");
        if (exitBtn != null)
        {
            exitBtn.onClick.AddListener(UIManager.Instance.Exit);
        }
    }
}
