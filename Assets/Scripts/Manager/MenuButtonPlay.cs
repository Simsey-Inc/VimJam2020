using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonPlay : MonoBehaviour
{
    #region Private Variables
    MusicManager musicManager;
    #endregion

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }

    public void PlayGame()
    {
        musicManager.PlayMainSong();
        SceneManager.LoadScene("Intro");
    }

}
