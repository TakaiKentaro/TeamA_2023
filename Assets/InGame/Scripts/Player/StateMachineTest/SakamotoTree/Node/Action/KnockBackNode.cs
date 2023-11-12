using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackNode : ActionNode
{
    [SerializeField] private float _knockBackPower;
    [Header("�m�b�N�o�b�N��Animarion�̖��O")]
    [SerializeField] private string _knockBackAnim; 
    protected override void OnExit(Environment env)
    {
      
    }

    protected override void OnStart(Environment env)
    {
      
    }

    protected override State OnUpdate(Environment env)
    {
        Vector3 distination = (env.MySelf.transform.position - env.Target.transform.position).normalized;
        env.MySelfRb.AddForce(distination * _knockBackPower, ForceMode.Impulse);
        return State.Success;
    }
}
