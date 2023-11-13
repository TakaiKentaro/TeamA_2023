using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �`�F�b�N�|�C���g��ʉ߂���Ƃ��̏��� </summary>
public class CheckPoint : MonoBehaviour
{
    [SerializeField] RestartController _restartCon = default; //��USerializeField�ɂ��Ă܂��B�����u���̂ŃV���O���g���ɂ�����C���X�^���X�ŒT������
    [SerializeField, Tooltip("�񕜂���HP�̑傫��")] float _healHpSize = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHp>(out var playerHp))
        {
            playerHp.ApplyHeal(_healHpSize);    //Player��HP���񕜂���
            _restartCon.SetRestartPos(gameObject.transform);        //���X�^�[�g�̍��W��ς���
            Debug.Log($"���X�^�[�g���W��{gameObject.transform.position}�ɕύX�B");
        }
    }
}
