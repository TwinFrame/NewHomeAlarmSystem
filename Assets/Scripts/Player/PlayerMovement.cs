using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpPower;

	private bool _isRunning;
	private float _speedWalk;
	private float _speedRun;
	private float _currentSpeed;
	private PlayerAnimation _playerAnimation;

	private void Start()
	{
		_playerAnimation = GetComponent<PlayerAnimation>();
	}

	private void Update()
	{
		_isRunning = _playerAnimation.GetIsRunning();

		_speedWalk = _speed;
		_speedRun = _speed * 1.6f;

		if (!_isRunning)
		{
			_currentSpeed = _speedWalk;
		}
		else
		{
			_currentSpeed = _speedRun;
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.Translate(_currentSpeed * Time.deltaTime * -1, 0, 0);
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, _currentSpeed * Time.deltaTime * _jumpPower, 0);
		}
	}
}
