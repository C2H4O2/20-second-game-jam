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
    private bool timerOn;
    private void Update() {
        if(time > 0 && timerOn) {
            time -= Time.deltaTime;
            seconds = (int)Math.Floor(time);
            milliseconds = MillisecondTruncate(time);
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
