using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �`�F�b�N�|�C���g��ʉ߂���Ƃ��̏��� </summary>
public class CheckPoint : MonoBehaviour
{
    [SerializeField]RestartController _setPos = default; //��USerializeField�ɂ��Ă܂��B�����u���̂ŃV���O���g���ɂ�����C���X�^���X�ŒT������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player��HP���񕜂���
        Debug.Log("HP��");
        //���X�^�[�g�̍��W��ς���
        Debug.Log($"���X�^�[�g���W��{ gameObject.transform.position}�ɕύX����܂����B");
        _setPos.SetRestartPos(gameObject.transform);
    }
}
