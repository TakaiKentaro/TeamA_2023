using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
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
        Reactive,
    }

    //�����O�̃X�v���C�g
    [SerializeField] private SpriteRenderer beforeImage = null;
    //���ꂽ��̃X�v���C�g
    [SerializeField] private SpriteRenderer afterImage = null;
    //���݂̃X�v���C�g
  �@private SpriteRenderer currentImage = null;
    //���ꂪ�����܂ł̎���
    [SerializeField] private float timeLimit = 5f;
    //�v���C���[������ɏ���Ă��鎞��
    private float totalTime = 0f;
    private State state = State.Wait;
    private Collider2D col;
    [SerializeField] private PlayerEnvroment _env;

    public void Start()
    {
        state = State.Wait;
        currentImage = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        currentImage.sprite = beforeImage.sprite;
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
                if (ReceiveForce())
                {
                    totalTime = 0;
                    state = State.Reactive;
                }
                break;
            case State.Reactive:
                Debug.Log("Reactive");
                Reactive();
                if (ReceiveForce())
                {
                    totalTime = 0;
                    state = State.Wait;
                }
                break;
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


    private void Reactive()
    {
        currentImage.sprite = beforeImage.sprite;
        col.enabled = true;
        Debug.Log("Reactive");
    }

    private void Corpse()
    {
        currentImage.sprite = afterImage.sprite;
        col.enabled = false;
        Debug.Log("Corpse");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            state = State.Init;
            Debug.Log("Enter");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" && col.enabled)
        {
            totalTime = 0;
            state = State.Wait;
            Debug.Log("Exit");
        }
    }
}
