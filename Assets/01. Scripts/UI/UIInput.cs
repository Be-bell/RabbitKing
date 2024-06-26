using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIInput : MonoBehaviour
{
    UnityEngine.InputSystem.PlayerInput inputAction;

    public event Action SkipEvent;
    public Intro intro;

    InputActionMap actionMap;

    private void Start()
    {
        inputAction = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        actionMap = inputAction.currentActionMap;
        InputAction menuUI = actionMap.actions[(int)UIInputActions.MENUUI];
        InputAction skip = actionMap.actions[(int) UIInputActions.SKIP];
        menuUI.performed += MenuUI;
        skip.performed += SkipIntro;
    }

    public void MenuUI(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Scene.START) return;

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

    public void SkipIntro(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)Scene.INTRO) return;

        if(intro == null)
        {
            intro = FindObjectOfType<Intro>();
        }

        if (intro != null && context.action.phase == InputActionPhase.Performed)
        {
            intro.SkipScene();
        }
    }
}

public enum UIInputActions
{
    NONE = -1,
    MENUUI,
    SKIP
}