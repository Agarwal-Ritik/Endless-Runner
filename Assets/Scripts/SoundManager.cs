using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Coin, Jump, GameOver, StartGame;
    public static AudioClip JumpSound, CoinSound, GameOverSound, StartGameSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        JumpSound = Jump;
        CoinSound = Coin;
        GameOverSound = GameOver;
        StartGameSound = StartGame;
    }

    public static void PlaySound(string soundClip){
        switch(soundClip){
            case "Coin":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Game Over":
                audioSrc.PlayOneShot(GameOverSound);
                break;
            case "Start Game":
                audioSrc.PlayOneShot(StartGameSound);
                break;
        }
    }
}
