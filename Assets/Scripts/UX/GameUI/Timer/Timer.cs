using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private bool timerOn;
    [SerializeField] private Image timerHandleImage;
    [SerializeField] private Image timerBaseImage;
    [SerializeField] private AudioClip alarmSound;
    [SerializeField] private AudioClip alarmLowTimeSound;
    private bool playedLowTimeSound = false;
    
    public UnityEvent timeUp;

    public float Time { get => time; set => time = value; }
    public bool TimerOn { get => timerOn; set => timerOn = value; }

    private void Update() {
        if (Time <= 0 && TimerOn == true) {
            TimerOn = false;
            timeUp.Invoke();
        }
        if(Time > 0 && TimerOn) {
            Time -= UnityEngine.Time.deltaTime;
            RotateHandle();
        }
        
        if (0 < Time && Time < 8) {
            AlertLowTime();
        }
    }

    public void PlayAlarmSound() {
        SoundFXManager.instance.PlaySoundFXClip(alarmSound, transform, 1f);
    }

    private void PlayLowTimeSound() {
        if(!playedLowTimeSound) {
            SoundFXManager.instance.PlaySoundFXClip(alarmLowTimeSound, transform, 0.5f);
            playedLowTimeSound = true;
        }
    }

    private void RotateHandle() {
        timerHandleImage.transform.Rotate(new Vector3(0, 0, 1), -18*UnityEngine.Time.deltaTime);
    }

    private void AlertLowTime() {
        PlayLowTimeSound();
        float realTime = 20 - Time;
        float r = (float)(128 * Math.Sin(Math.PI  * realTime) * Math.Sin(Math.PI * realTime));
        float g = r * 0.3f; // Add a bit of green to lighten the red
        float b = r * 0.3f; // Add a bit of blue to lighten the red
        timerBaseImage.color = new Color(r / 255f, g / 255f, b / 255f);
    }

}
