using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class RespawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _respawnTimeDelay;

    private float _runningTime;
    private Vector3 _instantiatePoint;

    private void Awake()
    {
        _instantiatePoint = transform.position;
    }

    private void Update()
    { 
        _runningTime += Time.deltaTime;

        if (_runningTime >=_respawnTimeDelay)
        {
            GameObject newObject = Instantiate(_object, _instantiatePoint, Quaternion.identity);
            _runningTime = 0;
        }
    }
}
