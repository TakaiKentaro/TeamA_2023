using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

//�v���C���[���n�ʂ��痎����������n�_�ɍŌ�ɗ����Ă�������ɖ߂������B
public class Ground : MonoBehaviour
{
    [SerializeField] private PlayerEnvroment _env = null;
    [SerializeField] private Transform _spawnPosition = null;
    [SerializeField] private Vector2 _fallPosition = new Vector2(0,-4);

    void Update()
    {
        if(_env.PlayerTransform.transform.position.y <= _fallPosition.y)
        {
            _env.PlayerTransform.position = _spawnPosition.position; 
        }
    }
}
