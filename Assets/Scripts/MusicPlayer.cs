using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        // print("Number of music players in this scene = " + numMusicPlayer);
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
            // int newNumMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
            // print("After destroy - New number of music players in this scene = " + newNumMusicPlayer);
        }
        else
        {
        DontDestroyOnLoad(gameObject);
        }
    }
}
