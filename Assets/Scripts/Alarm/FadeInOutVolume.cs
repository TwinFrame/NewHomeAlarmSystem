using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HouseAlarmAnimation))]

public class FadeInOutVolume : MonoBehaviour
{
	[SerializeField] private float _speed;

	private AudioSource _audioSource;
	private bool _isAlarm = false;
	private float _targetVolume;
	private float _currentVolume;
	private float _currentTime;

	private Coroutine _startFadeInJob;
	private Coroutine _startFadeOutJob;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		_audioSource.volume = 0;
	}

	public void StartAlarm()
	{
		_isAlarm = true;
	}

	public void StopAlarm()
	{
		_isAlarm = false;
	}

	public void StartFadeInPlay()
	{
		if (_startFadeOutJob != null)
		{
			StopCoroutine(_startFadeOutJob);
		}

		_audioSource.Play();
		_startFadeInJob = StartCoroutine(FadingSound());
	}

	public void StartFadeOutPlay()
	{
		if (_startFadeInJob != null)
		{
			StopCoroutine(_startFadeInJob);
		}

		_startFadeOutJob = StartCoroutine(FadingSound());
	}

	private IEnumerator FadingSound()
	{
		if (_isAlarm)
		{
			_targetVolume = 1;
		}
		else
		{
			_targetVolume = 0;
		}

		_currentVolume = _audioSource.volume;
		_currentTime = 0;

		while (_currentVolume >= 0 && _currentVolume <= 1)
		{
			_currentTime += _speed * Time.deltaTime;

			_audioSource.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _currentTime);

			yield return null;
		}
	}
}