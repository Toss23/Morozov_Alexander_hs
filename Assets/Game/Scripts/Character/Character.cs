using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Movable))]
public class Character : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animation _idleAnimation;
    [SerializeField] private Movable _movable;

    [Header("States")]
    [SerializeField] private State _startState;
    [SerializeField] private State _deathState;

    private State _currentState;
    private Points _points;
    private Base _base;

    public Animation IdleAnimation { get { return _idleAnimation; } }
    public Movable Movable { get { return _movable; } }
    public Points Points { get { return _points; } }
    public Base Base { get { return _base; } }

    private void Awake()
    {
        SetState(_startState);
    }

    public void Init(Vector2 startPosition, Points points, Base basePoint)
    {
        _points = points;
        _base = basePoint;
        _movable.Init(startPosition);
    }

    public void SetState(State state)
    {
        if (_currentState.CanBeStoped)
        {
            _currentState?.OnFinish();
            _currentState = Instantiate(state);
            _currentState.Init(this);
        }
    }

    private void Update()
    {
        if (_currentState.IsFinished == false)
            _currentState.Run();
        else
            SetState(_currentState.StateOnFinish);

        SetPosition(_movable.Position);
    }

    private void SetPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.y);
    }
}