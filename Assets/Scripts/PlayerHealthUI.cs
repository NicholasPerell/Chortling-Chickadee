using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
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
        rect.anchorMax = new Vector2(player.currentMaxHealth/player.endGameMaxHealth, rect.anchorMax.y);
    }

    void BarFill()
    {
        barFill.fillAmount = player.currentHealth / player.currentMaxHealth;
    }
}
