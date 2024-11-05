using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private bool timerOn;
    [SerializeField] private Image timerHandleImage;
    [SerializeField] private Image timerBaseImage;

    public float Time { get => time; set => time = value; }
    public bool TimerOn { get => timerOn; set => timerOn = value; }

    private void Update() {
        if (Time <= 0) {
            TimerOn = false;
        }
        if(Time > 0 && TimerOn) {
            Time -= UnityEngine.Time.deltaTime;
            RotateHandle();
        }
        
        if (0 < Time && Time < 8) {
            AlertLowTime();
        }
    }

    private void RotateHandle() {
        timerHandleImage.transform.Rotate(new Vector3(0, 0, 1), -18*UnityEngine.Time.deltaTime);
    }

    private void AlertLowTime() {
        float realTime = 20 - Time;
        float r = (float)(128 * Math.Sin(Math.PI  * realTime) * Math.Sin(Math.PI * realTime));
        float g = r * 0.3f; // Add a bit of green to lighten the red
        float b = r * 0.3f; // Add a bit of blue to lighten the red
        timerBaseImage.color = new Color(r / 255f, g / 255f, b / 255f);
    }

}
