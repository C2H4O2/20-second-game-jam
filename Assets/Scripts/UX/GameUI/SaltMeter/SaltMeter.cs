using UnityEngine;
using UnityEngine.UI;

public class SaltMeter : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void ChangeSliderValue(int num) {
        slider.value = num;
    }
    
}
