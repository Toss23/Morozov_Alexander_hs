using System;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public event Action OnFinishMoving;

    [SerializeField] private float _movespeed;

    private Vector2 _position;
    private Vector2 _targetPosition;

    public Vector2 Position { get { return _position; } }
    public Vector2 TargetPosition { set { _targetPosition = value; } }
    public bool InTargetPosition
    {
        get
        {
            return _position == _targetPosition;
        }
    }

    public void Init(Vector2 startPosition)
    {
        _position = startPosition;
        _targetPosition = startPosition;
    }

    public void ResetTarget()
    {
        _targetPosition = _position;
    }

    private void Update()
    {
        MoveTo(_targetPosition, Time.deltaTime);
        if (InTargetPosition)
            OnFinishMoving?.Invoke();
    }

    private void MoveTo(Vector2 targetPosition, float deltaTime)
    {
        _position = Vector3.MoveTowards(_position, targetPosition, _movespeed * deltaTime);
    }
}