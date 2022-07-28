using UnityEngine;

[CreateAssetMenu(fileName = "Patrolling State", menuName = "States/Patrolling State")]
public class PatrollingState : State
{
    private Movable _movable;

    public override void Init(Character character)
    {
        base.Init(character);

        Point point = _character.Points.GetRandomPoint();
        _movable = _character.Movable;
        _movable.TargetPosition = point.Position;
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