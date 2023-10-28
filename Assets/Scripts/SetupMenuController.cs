using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class SetupMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuController mainMenu;
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI taskNameText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer;

    private void OnEnable()
    {
        inputText.text = "";
        taskNameText.text = "";

        timer = 0.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Convert the float timer value to a TimeSpan
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        // Format the TimeSpan
        string formattedTimer;
        if (timeSpan.Hours >= 1)
        {
            // Format the TimeSpan as "hh:mm:ss"
            formattedTimer = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
        else
        {
            // Format the TimeSpan as "mm:ss" when it's less than an hour
            formattedTimer = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        }
        timerText.text = formattedTimer;
    }

    public void StartButton()
    {
        float time = 0.0f;

        string s = inputText.text.Substring(0, inputText.text.Length - 1); 
        if (float.TryParse(s, out time) && taskNameText.text != "")
        {
            mainMenu.StartTimer(time, taskNameText.text);
            MenuManager.Instance.TurnMenuOff(MenuIndexes.Setup, MenuIndexes.Main, true);
        }
    }
}
