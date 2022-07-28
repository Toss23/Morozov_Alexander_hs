using UnityEngine;

[CreateAssetMenu(fileName = "Death State", menuName = "States/Death State")]
public class DeathState : State
{
    private Movable _movable;

    public override void Init(Character character)
    {
        base.Init(character);

        _movable = _character.Movable;
        _movable.ResetTarget();
    }
}