using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UICountDown : MonoBehaviour
{
    public static float TimerBonus = 0;

    private Text _countDownText;

    private GameObject player;
    private CharacterController characterController;
    private AudioSource playerAudio;
    
    private float _countDownTimerDuration;
    private float _countDownTimerStartTime;

    string timerMessage;
    int timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        _countDownText = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("PlayerFPS");
        characterController = player.GetComponent<CharacterController>();
        playerAudio = player.GetComponent<AudioSource>();

        SetUpCountDownTimer(10); // this is the time that will be provide to the user
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerBonus > 0)
        {
            _countDownTimerStartTime += TimerBonus;
            TimerBonus = 0; // reset the variable or it will generate a bug
        }

        timeLeft = (int)CountDownTimeRemaning();
        if(timeLeft > 0)
        {
            timerMessage = "Timer: " + LeadingZero(timeLeft);
        }
        else
        {
            timerMessage = "Game Over";
            characterController.enabled = false;
            playerAudio.enabled = false;
        }

        _countDownText.text = timerMessage;

    }

    // This will setup the timing 
    void SetUpCountDownTimer(float DelayInSeconds)
    {
        _countDownTimerDuration = DelayInSeconds;
        _countDownTimerStartTime = Time.time;
    }

    private float CountDownTimeRemaning()
    {
        float _elapsedSeconds = Time.time - _countDownTimerStartTime;
        float _timeLeft = _countDownTimerDuration - _elapsedSeconds;
        return _timeLeft;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(3, '0'); 
    }
}
