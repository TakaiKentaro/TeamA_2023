using UnityEngine;
using Action2D;

/// <summary> ���X�^�[�g���̏��� </summary>
public class RestartController : MonoBehaviour
{
    [SerializeField, Tooltip("Player��Prefab")] PlayerController _pController = default;
    [SerializeField] GameObject _scenePlayer;
    [SerializeField] GameObject _playerPrefab;
    [Tooltip("���X�^�[�g������W")]
    Transform _restartPos = default;
    public Transform ReStartPos => _restartPos;
    private GameObject _playerObj;

    private void Start()
    {
        _playerObj = _scenePlayer;
    }

    /// <summary> Player�����S������Ă΂�� </summary>
    public GameObject Restart()
    {
        //Player�̃C���X�^���X��������������B�V���O���g���Ƃ̌��ˍ���
        Destroy(_playerObj);       
        _playerObj = Instantiate(_playerPrefab, _restartPos.position, _restartPos.rotation);   //Player�̃X�|�[��
        _pController = _playerObj.GetComponentInChildren<PlayerController>();
        return _playerObj;
    }


    /// <summary> �`�F�b�N�|�C���g��ʉ߂����Ƃ��ɌĂ΂�� </summary>
    /// <param name="restartPos">�`�F�b�N�|�C���g�̍��W</param>
    public void SetRestartPos(Transform restartPos)
    {
        _restartPos = restartPos;
    }
}
