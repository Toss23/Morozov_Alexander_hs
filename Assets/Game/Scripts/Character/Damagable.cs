using System;
using UnityEngine;

// ��� ���������� ������� � ����������� ����� �����������t ���� �������
// ��� ���� ����� �� ������� ����� �� ���������� �������, ������� �� �� ������
public class Damagable : Clickable3D
{
    public event Action<int, int> OnDamaged;
    public event Action OnDeath;

    [SerializeField] private int _hpMax;
    [SerializeField] private int _damageOnTouch;

    private int _hp;

    public void Init()
    {
        _damageOnTouch = Mathf.Abs(_damageOnTouch);
        _hp = _hpMax;
    }

    public override void OnClick()
    {
        Damage();
    }

    private void Damage()
    {
        if (_hp > 0)
        {
            _hp -= _damageOnTouch;
            if (_hp <= 0)
            {
                _hp = 0;
                OnDeath?.Invoke();
            }
            OnDamaged?.Invoke(_hp, _hpMax);
        }
    }
}