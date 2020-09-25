using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private List<AudioSource> music;
    #endregion

    private void Awake()
    {
        music[0].Play();
        DontDestroyOnLoad(gameObject);
    }
}
