//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using System.Threading;

public class PlayerAttack : IPlayerState, IPlayerAttack
{
    public IReadOnlyReactiveProperty<float> CurrentWaterNum => _currentWaterNum;
    public IReadOnlyReactiveProperty<float> MaxWaterNum => _maxWaterNum;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Transform _eimPos;
    [Header("最初の最大の水の量")]
    [SerializeField] private float _firstMaxWater;
    [Header("１発の水の消費量")]
    [SerializeField] private float _waterConsumption;
    [Header("連射のレート")]
    [SerializeField] private float _waterRate;
    private readonly ReactiveProperty<float> _currentWaterNum = new ReactiveProperty<float>();
    private readonly ReactiveProperty<float> _maxWaterNum = new ReactiveProperty<float>();

    private PlayerEnvroment _env;


    public void SetUp(PlayerEnvroment env, CancellationToken token)
    {
        _env = env;
        _maxWaterNum.Value = _firstMaxWater;
        _currentWaterNum.Value = _firstMaxWater;
        InputProvider.Instance.SetEnterInputAsync(InputProvider.InputType.Attack, Attack);
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {

    }

    private async UniTaskVoid Attack()
    {
        _env.AddState(PlayerStateType.Attack);
        Debug.Log(InputProvider.Instance.GetStayInput(InputProvider.InputType.Attack));

        do
        {
            _currentWaterNum.Value -= _waterConsumption;
            //_env.PlayerAnim.AttackAnim(true);

            var bulletCs = UnityEngine.Object.
                Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation).GetComponent<TestBullet>();
            bulletCs.SetShotDirection((_eimPos.transform.position - _env.PlayerTransform.transform.position).normalized);
            CriAudioManager.Instance.PlaySE("CueSheet_0", "SE_prayer_attack");
            await UniTask.WaitForSeconds(_waterRate);
        }
        while (InputProvider.Instance.GetStayInput(InputProvider.InputType.Attack));
        
        _env.RemoveState(PlayerStateType.Attack);
    }

    private void CancelAttak() 
    {
        _env.PlayerAnim.AttackAnim(false);
        _env.RemoveState(PlayerStateType.Attack);
    }

    public void Dispose()
    {
        _maxWaterNum.Dispose();
        _currentWaterNum.Dispose();
    }
}
