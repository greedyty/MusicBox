using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Songs
{
    public string MusicName;
    public Sprite MusicCover;
    public AudioClip MusicClip;

    public AudioClip GetMusicClip()
    {
        return MusicClip;
    }

    // Get the MusicCover of this song
    public Sprite GetMusicCover()
    {
        return MusicCover;
    }

    // Get the MusicName of this song
    public string GetMusicName()
    {
        return MusicName;
    }
}
