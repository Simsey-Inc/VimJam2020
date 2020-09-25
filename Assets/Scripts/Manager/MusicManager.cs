using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private List<AudioSource> music;

    [SerializeField]
    private int framesToPhase;
    #endregion

    #region Private Variables
    private AudioSource currentlyPlaying;
    #endregion

    private void Awake()
    {
        music[0].Play();
        currentlyPlaying = music[0];
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMainSong()
    {
        StartCoroutine(PhaseInTrack(music[1]));
    }

    private IEnumerator PhaseInTrack(AudioSource newSong)
    {
        float maxVolNewSong = newSong.volume;
        newSong.volume = 0;
        float amountToDecreaseOldSong = currentlyPlaying.volume / framesToPhase;
        float amountToIncreaseNewSong = maxVolNewSong / framesToPhase;

        newSong.Play();
        for (int i = 0; i < framesToPhase; i++)
        {
            currentlyPlaying.volume -= amountToDecreaseOldSong;
            newSong.volume += amountToIncreaseNewSong;
            yield return new WaitForEndOfFrame();
        }
        currentlyPlaying.Stop();
        currentlyPlaying = newSong;
    }
}
