using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicBox : MonoBehaviour
{
    public MusicSystem MusicSystem;

    public Text JukeboxText;

    public IndividualRadio Jukebox;

    private IndividualRadio CurrentRadio;

     void Start()
    {
        List<Songs> playList = MusicSystem.Songs;

        CurrentRadio = Jukebox;

        CurrentRadio.Init(playList);
    }

    #region Speaker
    [Header("Speaker Use")]
    public AudioSource AudioSource;
    public float Boost = 0.5f;
    float[] spectrum = new float[64];

    public void StartSpeaker()
    {
        StartCoroutine("theMusic");
    }

    public void StopSpeaker()
    {
        StopCoroutine("theMusic");
    }


    private IEnumerator theMusic()
    {
        List<int> i = new List<int>();
        int t = 0;

        while (this.AudioSource.isPlaying)
        {
            this.AudioSource.GetSpectrumData(this.spectrum, 0, FFTWindow.Rectangular);
            float max = GetSoundLevel(this.spectrum) * 2;
            int m = GetIndex(max, 10);

            if (t < 20)
            {
                if (i.Count < 10)
                {
                    i.Add(m);
                }
                else
                {
                    i.Add(m);
                    i.RemoveAt(0);
                }
                t += m;
            }
            else
            {
                int total = 0;
                foreach (int j in i)
                {
                    total += j;
                }
                CurrentRadio.DoAnim(total);
                t = 0;
                i = new List<int>();
            }
            yield return new WaitForSeconds(0.025f);
        }

        CurrentRadio.SpeakerReset();
    }

    private float GetSoundLevel(float[] samples)
    {
        float max = 0;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            max += Mathf.Clamp((spectrum[i] * Boost), 0, 1);
        }

        return max;
    }

    private int GetIndex(float ratio, float arrayLength)
    {
        int m = Mathf.Clamp((int)((arrayLength * ratio) - 1f), 0, (int)arrayLength - 1);
        return m;
    }
    #endregion
}