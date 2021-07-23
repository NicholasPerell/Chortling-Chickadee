using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartSettingsScreen : MonoBehaviour
{
    [SerializeField] float timeToFadeIntoLogo, timeOnLogo, timeFromLogoToAudio, timeToFadeAway;
    [SerializeField] Image blackoutImage;
    [SerializeField] GameObject logoPanel, audioPanel;

    // Start is called before the first frame update
    void Start()
    {
        DG.Tweening.Sequence mySequence = DOTween.Sequence();
        mySequence.Append(blackoutImage.DOFade(0, timeToFadeIntoLogo))
            .AppendInterval(timeOnLogo)
            .Append(blackoutImage.DOFade(1, timeToFadeIntoLogo / 2))
            .AppendCallback(EnterIntoStartOnComplete);
            //.Append(blackoutImage.DOFade(0, timeToFadeIntoLogo/2))
            //.AppendCallback(StartSequenceComplete);
    }

    void SwapPanels()
    {
        logoPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    void StartSequenceComplete()
    {
        blackoutImage.enabled = false;
    }

    public void EnterIntoStart()
    {
        blackoutImage.enabled = true;
        Tween myTween = blackoutImage.DOFade(1, timeToFadeAway);
        myTween.OnComplete(EnterIntoStartOnComplete);
    }

    void EnterIntoStartOnComplete()
    {
        SceneManager.LoadScene(1);
    }
}
