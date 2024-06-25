using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    private PlayerMove playerMove;
    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMove.isGround = true;
            playerMove.jumpWeights = 0;
            if(playerMove.isDown)
            {
                SoundManager.Instance.PlayEffectSound(EffectSoundTag.FALL);
                return;
            }
            SoundManager.Instance.PlayEffectSound(EffectSoundTag.LAND);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SoundManager.Instance.PlayBGM(BGMIndex.BG4);
            SceneManager.LoadScene((int)Scene.END);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMove.isGround = false;
            playerMove.saveX = 0;
        }
    }
}
