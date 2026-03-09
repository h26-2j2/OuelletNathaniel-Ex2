using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TMP_Text text;
    string originalText = "";

    void Start()
    {
        text = GetComponent<TMP_Text>();
        originalText = text.text;
    }

    void Update()
    {
        text.text = $"{originalText} {TimeSpan.FromSeconds(GameManager.instance.timer).Seconds}.{TimeSpan.FromSeconds(GameManager.instance.timer).Milliseconds}s";
    }
}
