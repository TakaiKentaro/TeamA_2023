using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �M�~�b�N�F�͗t </summary>
public class DeadLeaves : MonoBehaviour
{
    BoxCollider2D _defaultCollider = default;
    Animator _deadLeavesAnim = default;
    private void Start()
    {
        _defaultCollider = GetComponent<BoxCollider2D>();
        _deadLeavesAnim = GetComponent<Animator>();
    }

    /// <summary> Player����U�����󂯂��Ƃ��ɌĂ΂�� </summary>
    public void Attacked()
    {
        //�͗t���J���A�j���[�V�����Đ�
        _deadLeavesAnim.SetBool("IsAttacked", true);
    }


    /// <summary> 
    /// �ʂ�Ȃ��悤�ɂ��Ă����f�J���R���C�_�[��j������B
    /// �A�j���[�V�����C�x���g����Ă� 
    /// </summary>
    public void DestroyDefaultCollider()
    {
        Destroy(_defaultCollider);
    }

    /// <summary>
    /// �t���J�������Ƃ̌`�ɍ��킹�ăR���C�_�[������
    /// �A�j���[�V�����C�x���g����Ă� 
    /// </summary>
    public void SetNewCollider()
    {
        gameObject.AddComponent<PolygonCollider2D>();   //�Ƃ肠�����|���S���ɂ��Ă܂��B�d�l��s��ɍ��킹�ĕύX
    }
}
