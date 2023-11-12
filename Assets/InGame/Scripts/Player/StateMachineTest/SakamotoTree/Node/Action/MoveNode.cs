using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ���̋����܂őΏۂɋ߂Â����߂̃N���X
/// </summary>
public class MoveNode : ActionNode
{
    [SerializeField] private int _moveSpeed;
    [Header("�ǂ̒��x�܂ŋ߂Â����瓮���̂���߂邩")]
    [SerializeField] private float _rangeNum;
    [Header("�����}�[�N���o�����ǂ���")]
    [SerializeField] private bool _isDetection;
    [System.NonSerialized] private NavMeshAgent _agent;
    protected override void OnExit(Environment env)
    {
        env.MySelfAnim.SetBool("Move", false);
        _agent.SetDestination(env.MySelf.transform.position);
    }

    protected override void OnStart(Environment env)
    {
        _agent = env.MySelf.GetComponent<NavMeshAgent>();
        _agent.speed = _moveSpeed;
    }

    protected override State OnUpdate(Environment env)
    {
        if (env.ActorStateType == ActorStateType.Attack) return State.Success;

        var dist = (env.MySelf.transform.position - env.Target.transform.position).sqrMagnitude;
        if (dist < _rangeNum)
        {
            return State.Success;
        }

        if (_isDetection) 
        {
            env.ConditionAnim.SetTrigger("Detection");
        }
        env.MySelfAnim.SetBool("Move", true);
        _agent.SetDestination(env.Target.transform.position);
        return State.Running;
    }
}
