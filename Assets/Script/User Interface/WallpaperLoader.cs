using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI
{
    public class WallpaperLoader : MonoBehaviour
    {
        [Header("Wallpaper Holder")]
        public Image wallpaperHolder;
        [SerializeField] Animator imageAnimator;
        [SerializeField] CanvasGroup imageCanvasGroup;

        [Header("Wallpaper Parent")]
        public Image wallpaperParent;

        [Space]
        public List<Sprite> WallpaperSprites;

        WaitForSeconds WaitTime = new WaitForSeconds(30f);
        [SerializeField] int index = 0;

        IEnumerator Start()
        {
            yield return WaitTime;
            StartCoroutine(Wallpaper());
        }

        IEnumerator Wallpaper()
        {
            if (index < WallpaperSprites.Count- 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            if (imageAnimator != null)
            {
                imageAnimator.SetTrigger("FadeOut");

                while (imageCanvasGroup.alpha > 0.0f)
                {
                    yield return null;
                }

                wallpaperHolder.sprite = WallpaperSprites[index];

                imageAnimator.SetTrigger("FadeIn");
            }
            else
            {
                Debug.Log($"<color=red>Image Animator is Null</color>");
            }

            while(imageCanvasGroup.alpha <= 0.9f)
            {
                yield return null;
                
            }

            if (wallpaperParent != null)
            {
                Color32 randomColor = new Color32(
                    (byte)Random.Range(0, 255), //Red
                    (byte)Random.Range(0, 255), //Green
                    (byte)Random.Range(0, 255), //Blue
                    255 //Alpha (transparency)
                );
                wallpaperParent.color = randomColor;
            }

            yield return WaitTime;

            yield return Wallpaper();
        }
    }
}