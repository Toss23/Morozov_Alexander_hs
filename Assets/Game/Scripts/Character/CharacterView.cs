using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    public event Action OnClickIdle;
    public event Action OnClickPatrolling;
    public event Action OnClickReturnToBase;

    [SerializeField] private ProgressBar _hpBar;
    [SerializeField] private Button idleButton;
    [SerializeField] private Button patrollingButton;
    [SerializeField] private Button returnToBaseButton;

    public ProgressBar HpBar { get { return _hpBar; } }

    private void Awake()
    {
        idleButton.onClick.AddListener(() => OnClickIdle());
        patrollingButton.onClick.AddListener(() => OnClickPatrolling());
        returnToBaseButton.onClick.AddListener(() => OnClickReturnToBase());
    }
}