using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonPlay : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private MusicManager musicManager;
    #endregion

    public void PlayGame()
    {
        musicManager.PlayMainSong();
        SceneManager.LoadScene("Intro");
    }

}
