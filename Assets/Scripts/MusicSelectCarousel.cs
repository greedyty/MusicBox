using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MusicSelectCarousel : Oville.Carousel
{
    public MusicSystem MusicSystem;

    public MusicCarouselItem MusicCarouselItemPrefab;

    public void Init(List<Songs> songs)
    {
        Debug.Log(songs.Count);

        for (int i = 0; i < songs.Count; i++)
        {
            MusicCarouselItem musicCarouselItem = Instantiate(MusicCarouselItemPrefab, this.Content);
            musicCarouselItem.Init(songs[i], i, songs.Count - 1 - i, this);
            CarouselItems.Add(musicCarouselItem);
        }

        ListGoTo((int)(CarouselItems.Count - 1));
        this.MusicSystem.SelectMusic(((MusicCarouselItem)this.SelectedItem).MusicIndex);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        this.MusicSystem.OnStopPressed();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        this.MusicSystem.SelectMusic(((MusicCarouselItem)this.SelectedItem).MusicIndex);
    }

    public void GoToMusic(int i)
    {
        ListGoTo(i);
        this.MusicSystem.SelectMusic(((MusicCarouselItem)this.SelectedItem).MusicIndex);
    }
}
