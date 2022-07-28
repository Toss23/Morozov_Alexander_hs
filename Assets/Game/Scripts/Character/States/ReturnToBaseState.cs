using UnityEngine;

[CreateAssetMenu(fileName = "Return To Base State", menuName = "States/Return To Base State")]
public class ReturnToBaseState : State
{
    private Movable _movable;

    public override void Init(Character character)
    {
        base.Init(character);

        _movable = _character.Movable;
        _movable.TargetPosition = _character.Base.Position;
        _movable.OnFinishMoving += OnFinishMoving;
    }

    public override void OnFinish()
    {
        _movable.OnFinishMoving -= OnFinishMoving;
    }

    private void OnFinishMoving()
    {
        IsFinished = true;
    }
}