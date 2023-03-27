
using UnityEngine;
using UnityEngine.UI;


public class MusicCarouselItem : CarouselItem
{
    public Text SongName;

    private MusicSelectCarousel musicSelectCarousel;

    public int MusicIndex;

    private int buttonIndex;


    public void Init(Songs song, int musicIndex, int buttonIndex, MusicSelectCarousel musicSelectCarousel)
    {
        this.RectTransform = this.gameObject.GetComponent<RectTransform>();

        this.musicSelectCarousel = musicSelectCarousel;
        this.MusicIndex = musicIndex;
        this.buttonIndex = buttonIndex;

        //AudioClip audioClip = musicLibrary.GetMusicClipByMusicName(song);

        //string musicName = Path.GetFileNameWithoutExtension(song);

        this.Image.sprite = song.GetMusicCover();

        if (this.SongName) this.SongName.text = song.MusicName;
    }

    public void GoToMusic()
    {
        musicSelectCarousel.GoToMusic(this.buttonIndex);
    }
            

    public override void Zoom(Vector3 scale)
    {
        this.Image.color = new Color(this.Image.color.r, this.Image.color.g, this.Image.color.b, scale.x);
    }
}
