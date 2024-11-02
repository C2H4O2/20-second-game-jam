using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int saltCount;
    private SaltMeter saltMeter;
    public int SaltCount { get => saltCount; private set => saltCount = value; }

    private void Awake() {
        saltMeter = FindAnyObjectByType<SaltMeter>();
    }
    public void IncrementSalt() {
        SaltCount++;
        saltMeter.ChangeSliderValue(saltCount);
    }
}
