using UnityEngine;

/// <summary> ���X�^�[�g���̏��� </summary>
public class RestartController : MonoBehaviour
{
    [SerializeField, Tooltip("Player��Prefab")] PlayerController _pController = default;
    [Tooltip("���X�^�[�g������W")]
    Transform _restartPos = default;
    public Transform ReStartPos => _restartPos;

    /// <summary> Player�����S������Ă΂�� </summary>
    public void Restart()
    {
        //Player�̃C���X�^���X��������������B�V���O���g���Ƃ̌��ˍ���
        Destroy(_pController.gameObject);       
        Instantiate(_pController.gameObject, _restartPos.position, _restartPos.rotation);   //Player�̃X�|�[��
    }


    /// <summary> �`�F�b�N�|�C���g��ʉ߂����Ƃ��ɌĂ΂�� </summary>
    /// <param name="restartPos">�`�F�b�N�|�C���g�̍��W</param>
    public void SetRestartPos(Transform restartPos)
    {
        _restartPos = restartPos;
    }
}
