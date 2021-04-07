using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class AlarmDetect : MonoBehaviour
{
	[SerializeField] private UnityEvent _enter;
	[SerializeField] private UnityEvent _exit;

	private SpriteRenderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			player.GetComponent<Animator>().SetBool("isAlarm", true);

			_enter.Invoke();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			player.GetComponent<Animator>().SetBool("isAlarm", false);

			_exit.Invoke();
		}
	}
}
