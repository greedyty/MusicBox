using Oville.Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

 public class IndividualRadio : CanvasGroupToggle
{
    public Canvas RadioCanvas;
    public MusicSelectCarousel MusicSelectCarousel;
    public List<RectTransform> Speakers;

    public void Init(List<Songs> songs)
    {
        this.RadioCanvas.enabled = true;
        MusicSelectCarousel.Init(songs);
        this.MakeVisible();
    }

    public void DoAnim(int level)
    {
        float audioLevel = (float)level / 25f;
        if (audioLevel < 0.9f) audioLevel = 0.9f;
        if (audioLevel > 1.1f) audioLevel = 1.1f;

        for (int i = 0; i < Speakers.Count; i++)
        {
            Speakers[i].DOScale(audioLevel, 0.25f);
        }
    }

    public void SpeakerReset()
    {
        for (int i = 0; i < Speakers.Count; i++)
        {
            Speakers[i].DOScale(1f, 0.1f);
        }
    }
}

