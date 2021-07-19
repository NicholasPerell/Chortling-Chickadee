using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CreditsUIScrolling : MonoBehaviour

{

    public float timeBeforeMoving = 1.5f;

    public float amountToMoveUp = 2;

    public float timeToLerp = 30;

    [SerializeField] float timer;

    bool running = false;

    Vector2 startingPoints;

    RectTransform rect;

    // Start is called before the first frame update

    void Start()

    {

        Time.timeScale = 1;

        timer = timeBeforeMoving;

        rect = GetComponent<RectTransform>();

        startingPoints.x = rect.anchorMin.y;

        startingPoints.y = rect.anchorMax.y;

    }

    // Update is called once per frame

    void Update()

    {

        if (timer > 0)

        {

            timer -= Time.deltaTime;

            if (timer < 0) timer = 0;

            if (running)

            {

                rect.anchorMin = new Vector2(rect.anchorMin.x, startingPoints.x + amountToMoveUp * (1 - timer / timeToLerp));

                rect.anchorMax = new Vector2(rect.anchorMax.x, startingPoints.y + amountToMoveUp * (1 - timer / timeToLerp));

            }

            if (timer == 0)

            {

                if (!running)

                {

                    running = true;

                    timer = timeToLerp;

                }

            }

        }

    }

}
