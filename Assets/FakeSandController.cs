using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;

public class FakeSandController : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 3.0f)]
    float param;

    [SerializeField] Transform character;
    [SerializeField] Transform player;

    [SerializeField] SpriteRenderer bottle;
    [SerializeField] GameObject yarnCanvasPanel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        character = transform.GetChild(0);

        bottle = player.GetChild(4).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        yarnCanvasPanel = GameObject.FindObjectOfType<DialogueRunner>().transform.GetChild(0).gameObject;//GameObject.Find("Yarn Canvas Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = bottle.transform.position;

        float frequnency = 3;
        if (param < .5f)
        {
            character.localPosition = new Vector2(-4 * param, Mathf.Sin(frequnency * Mathf.PI * param));
        }
        else if (param > 2)
        {
            character.localPosition = new Vector2(-4 + 4 * (param - 2), 0);
        }
        else if(param > 1.5f)
        {
            character.localPosition = new Vector2(-4 * (param - 1), Mathf.Sin(frequnency * Mathf.PI * (param - 1)));
        }
        else
        {
            character.localPosition = new Vector2(-Mathf.Sin(2 * Mathf.PI * (param-.5f))-2, -Mathf.Cos(2 * Mathf.PI * (param - .5f)));
        }
    }

    [YarnCommand("revealSand")]
    public void GrandReveal()
    {
        Time.timeScale = 1;

        bottle.enabled = false;
        yarnCanvasPanel.SetActive(false);
        character.gameObject.SetActive(true);
        DOTween.defaultTimeScaleIndependent = false;
        DOTween.timeScale = 1;
        DOTween.To(() => param, x => param = x, 2.0f, 2.5f).OnComplete(EndReveal);
    }

    [YarnCommand("returnSand")]
    public void ReturnSand()
    {
        Time.timeScale = 1;
        Tween t = DOTween.To(() => param, x => param = x, 3.0f, 2.0f);
        t.OnComplete(EndReturn);
    }

    void EndReveal()
    {
        //Time.timeScale = 0;
        StartCoroutine(nameof(WaitBeforeReturningToYarn));
    }

    void EndReturn()
    {
        yarnCanvasPanel.SetActive(false);
        bottle.enabled = true;
        character.gameObject.SetActive(false);
        player.GetComponent<PlayerMovementController>().enabled = true;
        player.GetComponent<PlayerStatsController>().enabled = true;
        player.GetComponent<SandAbilityManager>().enabled = true;
    }

    IEnumerator WaitBeforeReturningToYarn()
    {
        //Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        yarnCanvasPanel.SetActive(true);
    }
}
