using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �M�~�b�N�F�ł̋��� </summary>
public class Poison : MonoBehaviour
{
    Collider2D _collider = default;
    Animator _poisonAnim = default;
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = false;
        _poisonAnim = GetComponent<Animator>();
    }

    /// <summary> Player����U�����󂯂��Ƃ��ɌĂ΂�� </summary>
    public void Detoxification()
    {
        //�ł������Ēʂ��悤�ɂȂ�BTrigger�̓A�j���[�V�����ŃI���ɂ��Ă܂�
        _poisonAnim.SetBool("IsAttacked", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player�����������Ƃ��Ƀ_���[�W�^����Ƃ�
    }

}
