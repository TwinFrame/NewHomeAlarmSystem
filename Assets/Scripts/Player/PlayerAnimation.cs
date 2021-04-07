using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]

public class PlayerAnimation : MonoBehaviour
{
	[SerializeField] private float _timeBeforeRunning;

	private Animator _animator;
	private float _runningTime;
	private Vector3 _rightDirect = new Vector3(1, 1, 1);
	private Vector3 _leftDirect = new Vector3(-1, 1, 1);

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (!Input.anyKey)
		{
			_animator.SetBool("isMoving", false);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_animator.SetTrigger("Attack");
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			_runningTime += Time.deltaTime;

			_animator.SetFloat("Speed", _runningTime);
			_animator.SetBool("isMoving", true);

			if (_runningTime >= _timeBeforeRunning)
			{
				_animator.SetBool("isRunning", true);
			}

			transform.localScale = _rightDirect;
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			_runningTime = 0;

			_animator.SetBool("isRunning", false);
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			_runningTime += Time.deltaTime;

			_animator.SetFloat("Speed", _runningTime);
			_animator.SetBool("isMoving", true);

			if (_runningTime >= _timeBeforeRunning)
			{
				_animator.SetBool("isRunning", true);
			}

			transform.localScale = _leftDirect;
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			_runningTime = 0;

			_animator.SetBool("isRunning", false);
		}
	}

	public bool GetIsRunning()
	{
		return _animator.GetBool("isRunning");
	}
}
