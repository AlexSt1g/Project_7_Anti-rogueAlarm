using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
            _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
            _alarm.TurnOff();
    }
}
