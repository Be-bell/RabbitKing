using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private UnityEngine.InputSystem.PlayerInput inputAction;

    private void Start()
    {
        inputAction = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        InputActionMap actionMap = inputAction.currentActionMap;
        InputAction pressSpace = actionMap.actions[0];

        pressSpace.performed += Title;
    }

    private void Title(InputAction.CallbackContext context)
    {
        SoundManager.Instance.PlayBGM(BGMIndex.BG1);
        SceneManager.LoadScene((int)Scene.START);
    }
}