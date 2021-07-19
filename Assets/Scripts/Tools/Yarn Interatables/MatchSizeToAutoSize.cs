using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchSizeToAutoSize : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI autoSizer;
    TextMeshProUGUI targetSizer;

    // Start is called before the first frame update
    void Start()
    {
        targetSizer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        targetSizer.fontSize = autoSizer.fontSize;
    }
}
