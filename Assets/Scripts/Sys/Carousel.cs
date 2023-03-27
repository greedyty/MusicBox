using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Oville.Items;

namespace Oville
{
    public class Carousel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        
        public enum Type { Vertical, Horizontal};
        [Header("Carousel menu type")]
        public Type MenuType = Type.Vertical;

        public CarouselItem CarouselItemPrefab;

        public RectTransform Content;

        protected Vector3 PosCorrection;

        protected List<CarouselItem> CarouselItems = new List<CarouselItem>();

        protected CarouselItem SelectedItem;

        [Header("Block Size")]
        public float BlockSize = 300f;

        public Vector3 ZoomOut = new Vector3(0.8f, 0.8f, 0.8f);
        public Vector3 ZoomIn = Vector3.one;     

        public virtual void Init(List<Item> items, Item activedItem = null)
        {
            for(int i = 0; i < items.Count; i++)
            {
                CarouselItem carouselItem = Instantiate(CarouselItemPrefab, Content);
                carouselItem.Init(items[i]);
                CarouselItems.Add(carouselItem);
            }

            if(activedItem != null)
            {
                for(int i = 0; i < CarouselItems.Count; i++)
                {
                    if(activedItem == CarouselItems[i].Item)
                    {
                        ListGoTo(i);
                    }
                }
            }
            else
            {
                if(CarouselItems.Count > 0)
                {
                    ListGoTo(0);
                }
            }
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            PosCorrection = Content.transform.position;
            if (MenuType == Type.Vertical)
            {
                PosCorrection.y -= eventData.position.y;
            }
            else
            {
                PosCorrection.x -= eventData.position.x;
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            int i;

            if (MenuType == Type.Vertical)
            {
                Content.transform.position = new Vector3(PosCorrection.x, PosCorrection.y + eventData.position.y, PosCorrection.z);
                i = GetItemNum(Content.localPosition.y);
                AdjustSelectedItemSize(i);
            }
            else
            {
                Content.transform.position = new Vector3(PosCorrection.x + eventData.position.x, PosCorrection.y, PosCorrection.z);
                i = GetItemNum(Content.localPosition.x);
                AdjustSelectedItemSize(-i);
            }

            
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            int i;

            if (MenuType == Type.Vertical)
            {
                i = GetItemNum(Content.localPosition.y);
                AdjustPos(i);
                AdjustSelectedItemSize(i);
            }
            else
            {
                i = GetItemNum(Content.localPosition.x);
                AdjustPos(i);
                AdjustSelectedItemSize(-i);
            }
        }

        protected virtual int GetItemNum(float localPos)
        {
            float f = localPos / BlockSize;            

            if (CarouselItems.Count % 2 != 0)
            {
                if (f < -1f * (int)(CarouselItems.Count / 2))
                {
                    f = -1f * (int)(CarouselItems.Count / 2);
                }
                else if (f > (int)(CarouselItems.Count / 2))
                {
                    f = CarouselItems.Count / 2;
                }
            }
            else
            {
                f -= 0.5f;

                if (f < -1f * (int)(CarouselItems.Count / 2))
                {
                    f = -1f * (int)(CarouselItems.Count / 2);
                }
                else if (f > (int)(CarouselItems.Count / 2) - 1)
                {
                    f = (int)(CarouselItems.Count / 2) - 1;
                }
            }

            if ((f + CarouselItems.Count) - ((int)f + CarouselItems.Count) > 0)
            {
                if ((f + CarouselItems.Count) - ((int)f + CarouselItems.Count) >= 0.5f)
                {
                    return((int)f + 1);
                }
                else
                {
                    return ((int)f);
                }
            }
            else
            {
                if ((f + CarouselItems.Count) - ((int)f + CarouselItems.Count) <= -0.5f)
                {
                    return ((int)f - 1);
                }
                else
                {
                    return ((int)f);
                }
            }
        }

        protected virtual void AdjustPos(int i)
        {
            float f = i;

            if(CarouselItems.Count % 2 == 0)
            {
                f += 0.5f;
            }

            if (MenuType == Type.Vertical)
            {
                Content.DOAnchorPosY(BlockSize * f, 0.25f);
            }
            else
            {
                Content.DOAnchorPosX(BlockSize * f, 0.25f);
            }
        }

        protected virtual void AdjustSelectedItemSize(int i)
        {
            if (MenuType == Type.Horizontal && CarouselItems.Count % 2 == 0) i--;

            int s = CarouselItems.Count / 2;

            for (int j = 0; j < CarouselItems.Count; j++)
            {
                if(j - s != i)
                {
                    CarouselItems[j].Zoom(ZoomOut);
                }
                else
                {
                    CarouselItems[j].Zoom(ZoomIn);
                    SelectedItem = CarouselItems[j];
                }
            }
        }

        protected virtual void ListGoTo(int i)
        {
            Debug.Log("List go to " + i);
            i -= CarouselItems.Count / 2;
            AdjustPos(i);
            if (MenuType == Type.Horizontal)
            {
                AdjustSelectedItemSize(-i);
            }
            else
            {
                AdjustSelectedItemSize(i);
            }
        }

        public virtual void ResetCarousel()
        {
            for (int i = CarouselItems.Count - 1; i >= 0; i--)
            {
                Destroy(CarouselItems[i].gameObject);
            }
            CarouselItems = new List<CarouselItem>();
            SelectedItem = null;
        }
    }
}