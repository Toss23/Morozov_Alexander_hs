using UnityEngine;

public class CharacterInit : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private CharacterView _characterView;

    [Header("States")]
    [SerializeField] private State _idleState;
    [SerializeField] private State _patrollingState;
    [SerializeField] private State _returnToBaseState;

    [Header("Base and Points")]
    [SerializeField] private Base _base;
    [SerializeField] private Points _points;

    private Character _character;

    private void Start()
    {
        _character = Instantiate(_characterPrefab);
        _character.name = "Character";
        _character.Init(_base.Position, _points, _base);
        _character.Enable();

        Enable();
    }

    public void Enable()
    {
        _character.Damagable.OnDamaged += (hp, hpMax) => _characterView.HpBar.SetProgress(hp, hpMax);
        _characterView.OnClickIdle += () => _character.SetState(_idleState);
        _characterView.OnClickPatrolling += () => _character.SetState(_patrollingState);
        _characterView.OnClickReturnToBase += () => _character.SetState(_returnToBaseState);
    }

    public void Disable()
    {
        _character.Damagable.OnDamaged -= (hp, hpMax) => _characterView.HpBar.SetProgress(hp, hpMax);
        _characterView.OnClickIdle -= () => _character.SetState(_idleState);
        _characterView.OnClickPatrolling -= () => _character.SetState(_patrollingState);
        _characterView.OnClickReturnToBase -= () => _character.SetState(_returnToBaseState);
    }
}