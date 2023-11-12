using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

[Serializable]
public class AttackNode : ActionNode
{
    [Header("�U����AnimParam")]
    [SerializeField] private string _attackParam;
    [Header("1���A�j���[�V�����̏I���Ƃ��ĉ����܂ōĐ����邩")]
    [SerializeField] private float _attackEndNum;
    [Header("�A�j���[�V�����̂ǂ̃^�C�~���O����U��������o����")]
    [SerializeField] private float _collisionDetectionStart, _collisionDetectionEnd;
    [Header("�����蔻��̑傫��")]
    [SerializeField] private float _radius;
    [Header("�����蔻��̒���")]
    [SerializeField] private float _maxDistance;
    [Header("�����蔻��̈ʒu����")]
    [SerializeField] private Vector3 _offset;
    [Header("����ɗ^����_���[�W")]
    [SerializeField] private float _damage;
    [NonSerialized] private bool _isAnimation;
    [NonSerialized] private bool _isComplete;
    [NonSerialized] private RaycastHit _hit;
    protected override void OnExit(Environment env)
    {

    }

    protected override void OnStart(Environment env)
    {

    }

    protected override State OnUpdate(Environment env)
    {
        if (_isComplete && _isAnimation)
        {
            _isComplete = false;
            _isAnimation = false;
            return State.Success;
        }
        else if (!_isAnimation)
        {
            _isAnimation = true;
            AttackAnim(env, _token.Token);
        }

        AttackEffect(env);
        return State.Running;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="env"></param>
    private async void AttackAnim(Environment env, CancellationToken token)
    {
        env.MySelfAnim.SetTrigger(_attackParam);
        env.AddState(ActorStateType.Attack);
        await UniTask.WaitUntil(() => !env.MySelfAnim.IsInTransition(0), cancellationToken: token);
        await UniTask.WaitUntil(() => env.MySelfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= _attackEndNum, cancellationToken: token);
        env.RemoveState(ActorStateType.Attack);
        _isComplete = true;
    }

    /// <summary>
    /// �U��������ɓ������������肵�������s�����\�b�h
    /// </summary>
    /// <param name="env"></param>
    private void AttackEffect(Environment env)
    {
        if (env.MySelfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= _collisionDetectionStart &&
           env.MySelfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= _collisionDetectionEnd)
        {
            ColliderHitCheck(env);
        }
    }

    /// <summary>
    /// �����Collider�ɓ����������ǂ���Check����
    /// </summary>
    /// <param name="env"></param>
    private void ColliderHitCheck(Environment env)
    {
        var myselfTransform = env.MySelf.transform;
        BehaviorHelper.OnDrawSphere(env.MySelf.transform, _radius, Vector3.up, _maxDistance);
        var HitColliderArray = Physics.OverlapSphere(myselfTransform.position + _offset + myselfTransform.forward, _radius);
        if (HitColliderArray.Length == 0) return;

        for (int i = 0; i < HitColliderArray.Length; i++) 
        {
            if (HitColliderArray[i].gameObject.TryGetComponent(out IDamageble damageCs))
            {
                Debug.Log("10�̃_���[�W��^����");
                damageCs.ReceiveDamage(_damage, env.MySelf.transform.position);
            }
        }
    }
}
