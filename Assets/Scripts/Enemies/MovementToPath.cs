using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MovementToPath : MonoBehaviour
{
	[SerializeField] private GameObject _enemyObject;
	[SerializeField] private Transform _path;
	[SerializeField] private float _speed;

	private Transform[] _points;
	private GameObject _enemy;
	private Vector3 _startPosition;
	private Vector3 _circlePath = new Vector3();
	private int _currentPoint;

	private void Start()
	{
		_points = new Transform[_path.childCount];

		for (int i = 0; i < _path.childCount; i++)
		{
			_points[i] = _path.GetChild(i);
		}

		_startPosition = _points[0].position;
		_enemy = Instantiate(_enemyObject, _startPosition, Quaternion.identity);
	}

	private void Update()
	{
		Transform target = _points[_currentPoint];

		Vector3 pathBetweenPoints = Vector3.MoveTowards(_enemy.transform.position, target.position, _speed * Time.deltaTime);

		_circlePath.Set(0, 0.01f * Mathf.Cos(Time.time * 6), 0);

		_enemy.transform.position = pathBetweenPoints + _circlePath;

		if (_enemy.transform.position == target.position)
		{
			_currentPoint++;

			if (_currentPoint >= _points.Length)
			{
				_currentPoint = 0;
			}
		}
	}
}
