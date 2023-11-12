using System;
using UnityEngine;

public class IfCheckThePerimeter : DecoratorNode
{
    [Header("�W�I�����m���鋗��")]
    [SerializeField] private float _sensingDistance;
    [Header("�߂Â����Ƃ��Ɏ��̃X�e�[�g�ɐi�ނ�")]
    [SerializeField] private State _approachingState;
    [Header("���ꂽ�Ƃ��Ɏ��̃X�e�[�g�ɐi�ނ�")]
    [SerializeField] private State _distanceState;
    protected override void OnExit(Environment env)
    {
       
    }

    protected override void OnStart(Environment env)
    {

    }

    protected override State OnUpdate(Environment env)
    {
        var dist = (env.MySelf.transform.position - env.Target.transform.position).sqrMagnitude;
        if (dist < _sensingDistance)
        {
            if (_approachingState == State.Running) return Child.update(env);
            Child.CurrentState = _approachingState;
            return _approachingState;
        }

        if (_distanceState == State.Running) return Child.update(env);
        Child.CurrentState = _distanceState;
        return _distanceState;
    }
}