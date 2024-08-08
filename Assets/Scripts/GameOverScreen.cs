using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI messageText;
    public void SetUp(float time, string message)
    {
        gameObject.SetActive(true);
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        messageText.text = message;
        timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
