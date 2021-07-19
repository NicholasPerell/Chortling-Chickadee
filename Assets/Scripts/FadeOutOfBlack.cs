using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeOutOfBlack : MonoBehaviour
{
    [SerializeField] float timeToFadeIn;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.enabled = true;
        Tween myTween = img.DOFade(0, timeToFadeIn);
        myTween.OnComplete(End);
    }

    void End()
    {
        img.enabled = false;
    }

}
