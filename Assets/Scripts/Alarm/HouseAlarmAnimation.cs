using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class HouseAlarmAnimation : MonoBehaviour
{
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	public void StartAlarmAnimation()
	{
		_animator.SetBool("isAlarm", true);
	}

	public void StopAlarmAnimation()
	{
		_animator.SetBool("isAlarm", false);
	}

	public bool GetIsAlarm()
	{
		return _animator.GetBool("isAlarm");
	}
}
