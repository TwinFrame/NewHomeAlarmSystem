using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class CreatePlayerOnStart : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _instantiatePoint;

    private void Start()
    {
        _instantiatePoint = transform.position;

        GameObject player = Instantiate(_player, _instantiatePoint, Quaternion.identity);

        Destroy(gameObject);     
    }
}
