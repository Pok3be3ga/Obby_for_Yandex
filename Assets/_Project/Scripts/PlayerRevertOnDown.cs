using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRevertOnDown : MonoBehaviour
{
    [SerializeField] private float _yPositionRevert = -30f;

    private Vector3 _currentCheckPoint;
    [SerializeField] private GameObject _player;
    void Start()
    {
        SetTransform(gameObject.transform.position);
        _currentCheckPoint = _player.transform.localPosition;
    }
    void Update()
    {
        if(gameObject.transform.position.y < _yPositionRevert)
        {
            Debug.Log(_player.transform.position);
            _player.transform.position = _currentCheckPoint;
        }
    }

    public void SetTransform(Vector3 transform)
    {
        _currentCheckPoint = transform;
    }
}
