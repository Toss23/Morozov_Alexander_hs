using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "States/Idle State")]
public class IdleState : State
{
    private Movable _movable;
    
    public override void Init(Character character)
    {
        base.Init(character);

        _character.IdleAnimation.Play();
        _movable = _character.Movable;
        _movable.ResetTarget();
    }

    public override void OnFinish()
    {
        _character.IdleAnimation.Stop();
    }
}