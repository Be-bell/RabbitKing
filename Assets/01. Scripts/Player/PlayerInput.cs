using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;


    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if (playerMove.isGround)
        {
            playerMove.GetX(context.ReadValue<Vector2>().x);
        }
    }

    public void JumpInput(InputAction.CallbackContext context)
    {

        if (playerMove.isGround && !playerMove.isDown)
        {
            playerMove.isCharging = true;
            if(context.started)
            {
                SoundManager.Instance.PlayEffectSound(EffectSoundTag.CHARGE);
            }

            if (context.action.phase == InputActionPhase.Canceled || context.action.phase == InputActionPhase.Performed)
            {
                playerMove.Jump();
            }
        }

    }
}
