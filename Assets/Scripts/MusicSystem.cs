using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


public class MusicSystem : MonoBehaviour 
{
    public List<Songs> Songs = new List<Songs>();

    public AudioSource MusicPlayer;

    public int CurrentPlayingMusicTrack;

    public Text MusicName;

    public MusicBox Speaker;

    public List<Sprite> PreviewImages;

    public PlayableDirector director;


    private Songs currentSong;


    //public void SetCurrentSong(string songName) 
    //{
    //    this.currentSongName = songName;
    //    this.SongIcon.sprite = this.musicLibrary.GetIconByMusicName(songName);
    //}

    public void LoadMusic(List<Songs> playList, Text musicName)
    {
        Songs = playList;
        MusicName = musicName;
    }

    public void SelectMusic(int index)
    {
        OnStopPressed();

        StopDirector();

        CurrentPlayingMusicTrack = index;

        currentSong = Songs[CurrentPlayingMusicTrack];

        MusicName.text = currentSong.MusicName;

    }


    public void NextMusic()
    {
        OnStopPressed();

        CurrentPlayingMusicTrack++;

        if (CurrentPlayingMusicTrack >= Songs.Count)
        {
            CurrentPlayingMusicTrack = 0;
        }

        currentSong = Songs[CurrentPlayingMusicTrack];

        MusicName.text = currentSong.MusicName;

    }

    public void PreviousMusic()
    {
        OnStopPressed();

        CurrentPlayingMusicTrack--;

        if (CurrentPlayingMusicTrack < 0)
        {
            CurrentPlayingMusicTrack = Songs.Count - 1;
        }

        currentSong = Songs[CurrentPlayingMusicTrack];

        MusicName.text = currentSong.MusicName;
    }

    public void OnPausePressed()
    {
        this.MusicPlayer.Pause();
    }

    public void OnStopPressed()
    {

        this.MusicPlayer.Stop();
    }

    public void OnPlayPressed()
    {
        if (this.MusicPlayer.isPlaying) return;

        LoadMusic(currentSong);
    }

    private void LoadMusic(Songs song)
    {
        Play(song.GetMusicClip());
    }

    private void Play(AudioClip clip)
    {
        if (clip != null)
        {
            if (this.MusicPlayer.clip != clip) this.MusicPlayer.clip = clip;
            this.MusicPlayer.Play();
            InfoSpeakerStart();
        }
    }

    public void StopDirector()
    {
        director.Stop();
    }

    private void InfoSpeakerStart()
    {
        Speaker.StartSpeaker();
    }

    private void InfoSpeakerFinish()
    {
        Speaker.StopSpeaker();
    }

    private void OnDestroy()
    {
        InfoSpeakerFinish();

        OnStopPressed();
    }

}
