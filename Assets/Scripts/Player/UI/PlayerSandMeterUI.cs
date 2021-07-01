using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSandMeterUI : MonoBehaviour
{
    public PlayerStatsController player;
    public Image barFill;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        player = GameObject.FindObjectOfType<PlayerStatsController>();

        FrameSize();
        BarFill();
    }

    // Update is called once per frame
    void Update()
    {
        FrameSize();
        BarFill();
    }

    void FrameSize()
    {
        rect.anchorMax = new Vector2(player.currentMaxSand / player.endGameMaxSand, rect.anchorMax.y);
    }

    void BarFill()
    {
        barFill.fillAmount = player.currentSand / player.currentMaxSand;
    }
}
