using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
    UnityEngine.InputSystem.PlayerInput inputAction;

    InputActionMap actionMap;

    private void Start()
    {
        inputAction = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        actionMap = inputAction.currentActionMap;
        InputAction menuUI = actionMap.actions[(int)UIInputActions.MENUUI];
        menuUI.performed += MenuUI;
    }

    public void MenuUI(InputAction.CallbackContext context)
    {
        if (UIManager.Instance.stackLength() == 0)
        {
            Time.timeScale = 0f;
            UIManager.Instance.PopUp<MenuUI>();
        }
        else
        {
            while (UIManager.Instance.stackLength() > 0)
            {
                UIManager.Instance.Exit();
            }
            Time.timeScale = 1.0f;
        }
    }
}

public enum UIInputActions
{
    NONE = -1,
    MENUUI
}