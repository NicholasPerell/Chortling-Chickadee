using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class SlideDeckController : MonoBehaviour
{
    [SerializeField] Sprite[] slides;
    int index;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        index = 0;
        img.sprite = slides[index];
    }

    [YarnCommand("nextSlide")]
    public void NextSlide()
    {
        index++;
        if (index < slides.Length)
        { 
            img.sprite = slides[index];
        }
        else
        {
            Debug.LogError("Ran out of slides on the slide deck");
        }
    }
}
