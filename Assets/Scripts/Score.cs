using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
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
        text.text = $"{originalText} {GameManager.instance.points}";
    }
}
