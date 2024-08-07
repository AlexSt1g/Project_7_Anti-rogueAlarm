using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeDelay = 1f;
    [SerializeField] private float _volumeChangeSpeed = 10f;

    private readonly float _maxVolume = 1f;
    private readonly float _minVolume = 0f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.volume = 0;
    }

    public void TurnOn()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        SetVolume(_maxVolume);
    }

    public void TurnOff()
    {
        SetVolume(_minVolume);
    }

    private void SetVolume(float volume)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolumeWithDelay(volume));
    }

    private IEnumerator ChangeVolumeWithDelay(float targetVolume)
    {
        var wait = new WaitForSeconds(_volumeChangeDelay);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);

            yield return wait;
        }

        if (_audioSource.volume <= _minVolume)
            _audioSource.Stop();
    }
}
