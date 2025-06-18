using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound BackgroundGame;
    [SerializeField] Sound BackgroundMenu;
    [SerializeField] Sound Jump;
    [SerializeField] Sound Run;
    [SerializeField] Sound Land;
    [SerializeField] Sound Climb;

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        AudioSource source = gameObject.GetComponent<AudioSource>();
        bool GamePaused = false;
        if (!GamePaused)
        {
            //Play game music
            source.clip = BackgroundGame.clip;
            source.name = BackgroundGame.name;
            source.pitch = BackgroundGame.pitch;
            source.volume = BackgroundGame.volume;
            source.loop = true;
            source.Play();

        }
        else
        {
            //Play menu music
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySoundEffectJump(int playerIndex)
    {

    }
    public void PlaySoundEffectLand(int playerIndex)
    {

    }
    public void PlaySoundEffectClimb(int playerIndex)
    {

    }
    public void PlaySoundEffectRun(int playerIndex)
    {

    }
    private AudioSource playerSource(int playerIndex)
    {
        GameObject player = GameObject.Find("Player " + playerIndex);
        if (player.GetComponent<AudioSource>() == null)
        {
            return player.AddComponent<AudioSource>();
        }
        else
        {
            return player.GetComponent<AudioSource>();
        }
    }
}
