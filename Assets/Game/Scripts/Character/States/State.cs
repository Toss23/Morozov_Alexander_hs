using UnityEngine;

public abstract class State : ScriptableObject
{
    [Header("State")]
    [SerializeField] private State _stateOnFinish;
    [SerializeField] private bool _canBeFinished = true;

    public bool IsFinished { get; protected set; }
    protected Character _character;

    public State StateOnFinish { get { return _stateOnFinish; } }
    public bool CanBeFinished { get { return _canBeFinished; } }

    public virtual void Init(Character character) 
    {
        _character = character;
    }

    public virtual void Run() { }

    public virtual void OnFinish() { }
}