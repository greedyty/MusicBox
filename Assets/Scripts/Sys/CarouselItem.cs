using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oville.Items;

public class CarouselItem : MonoBehaviour
{
    public Item Item;

    protected RectTransform RectTransform;

    public Image Image;

    private Songs song;

    public virtual void Init(Item item)
    {
        this.RectTransform = this.gameObject.GetComponent<RectTransform>();
        this.Image = this.gameObject.GetComponent<Image>();

        this.Item = item;

        Image.sprite = song.GetMusicCover();
    }

    public virtual void Zoom(Vector3 scale)
    {
        RectTransform.localScale = scale;
    }
}
