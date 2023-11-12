using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

public class LongRangeAttackNode : ActionNode
{
    [Header("�U����AnimParam")]
    [SerializeField] private string _attackParam;
    [Header("�����Œe�𔭎˂��邩")]
    [SerializeField] private float _firingStart;
    [Header("1���A�j���[�V�����̏I���Ƃ��ĉ����܂ōĐ����邩")]
    [SerializeField] private float _attackEndNum;
    [Header("���˂���e")]
    [SerializeField] private GameObject _bulletPrefab;
    [NonSerialized] private bool _isAnimation;
    [NonSerialized] private bool _isComplete;

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
            Debug.Log("�U���J�n");
            AttackAnim(env, _token.Token);
        }
        return State.Running;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="env"></param>
    private async void AttackAnim(Environment env, CancellationToken token)
    {
        env.MySelfAnim.SetTrigger(_attackParam);
        await UniTask.WaitUntil(() => !env.MySelfAnim.IsInTransition(0), cancellationToken: token);
        await UniTask.WaitUntil(() => env.MySelfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= _firingStart, cancellationToken: token);
        Instantiate(_bulletPrefab, env.BulletInsPos.position, env.BulletInsPos.rotation);
        await UniTask.WaitUntil(() => env.MySelfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= _attackEndNum, cancellationToken: token);
        _isComplete = true;
    }
}
