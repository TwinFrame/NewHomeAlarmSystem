using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectOnCircle : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private int _countObjects;
    [SerializeField] private float _radius;

    private int _fullRotationAngle = 360;

    private void Start()
    {
        float angelStep = _fullRotationAngle / _countObjects;

        for (int i = 0; i <= _countObjects; i++)
        {
            GameObject gameObjects = Instantiate(_object, new Vector3(_radius * Mathf.Sin(angelStep * (i + 1) * Mathf.Deg2Rad), _radius * Mathf.Cos(angelStep * (i + 1) * Mathf.Deg2Rad), 0), Quaternion.identity);
        }
    }
}
