using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfRemainingStrength : DecoratorNode
{
    [Header("�c��̗�")]
    [SerializeField] private float _remainingStrength;
    [Header("�ݒ肵���c��̗͂�艺�������ꍇ")]
    [SerializeField] private State _lowStrengthState;
    [Header("�ݒ肵���c��̗͂��ゾ�����ꍇ")]
    [SerializeField] private State _highStrengthState;
    protected override void OnExit(Environment env)
    {

    }

    protected override void OnStart(Environment env)
    {
        
    }

    protected override State OnUpdate(Environment env)
    {
        //�̗͂��ݒ肳�ꂽ�l�ȉ��������ꍇ
        if (env.ActorStatus.CurrentHp.Value <= _remainingStrength) 
        {
            return _lowStrengthState;
        }
        return _highStrengthState;
    }
}
