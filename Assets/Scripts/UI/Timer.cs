using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerSecondsText;
    [SerializeField] private TMP_Text timerMillisecondsText;
    [SerializeField] private float time;
    [SerializeField] private int seconds;
    [SerializeField] private int milliseconds; 
    [SerializeField] private bool timerOn;

    public float Time { get => time; set => time = value; }

    private void Update() {
        if(Time > 0 && timerOn) {
            Time -= UnityEngine.Time.deltaTime;
            seconds = (int)Math.Floor(Time);
            milliseconds = MillisecondTruncate(Time);
            timerSecondsText.text = seconds.ToString() + " : ";
            timerMillisecondsText.text = milliseconds.ToString();
        }
        else {
            seconds = 0;
            milliseconds= 0;
            timerSecondsText.text = seconds.ToString() + " : ";
            timerMillisecondsText.text = milliseconds.ToString();
        }
        
    }

    private int MillisecondTruncate(float num) {
        return (int)((decimal)num % 1 * 1000);
    }
}
