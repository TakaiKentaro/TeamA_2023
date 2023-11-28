using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;

//�������ԕt���̑���̏����B
public class TimeLimitGround : MonoBehaviour
{
    enum State 
    {
        Wait,
        Init,
        Corpse,
    }

    //���ꂪ�����܂ł̎���
    [SerializeField] private float timeLimit = 5f;
    [SerializeField] private List<TimeLimitGroundData> _dataList = new();
    [SerializeField] private SpriteRenderer _spRenderer;

    //�v���C���[������ɏ���Ă��鎞��
    private float totalTime = 0f;
    private State state = State.Wait;
    private Collider2D col;

    public void Start()
    {
        state = State.Wait;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        switch (state) {
            case State.Wait:
                Debug.Log("Wait");
                break;
            case State.Init:
                Debug.Log("Init");
                if (ReceiveForce())
                {
                    totalTime = 0;
                    state = State.Corpse;
                }
                break;
            case State.Corpse:
                Debug.Log("Corpse");
                Corpse();
                break;
        }

        var num = timeLimit / _dataList.Count;
        for (int i = 0; i < _dataList.Count; i++) 
        {
            if (totalTime >= timeLimit) break;
            Debug.Log(num);
            if (totalTime < num * (i + 1)) 
            {
                _spRenderer.sprite = _dataList[i].Sp;
                break;
            }
        }
    }

    private bool ReceiveForce()
    {
        totalTime += Time.deltaTime;
        if (timeLimit <= totalTime)
        {
            return true;
        }
        return false;
    }

   

    //�A�j���[�V�����C�x���g����Ăяo��
    private void Corpse()
    {
        Destroy(gameObject);
        Debug.Log("Corpse");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerHp>(out var playerHp))
        {
            state = State.Init;
            Debug.Log("Enter");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerHp>(out var playerHp) && col.enabled)
        {
            state = State.Wait;
            Debug.Log("Exit");
        }
    }

    [Serializable]
    public class TimeLimitGroundData 
    {
        public int ElapsedTime;
        public Sprite Sp;
    }
}
