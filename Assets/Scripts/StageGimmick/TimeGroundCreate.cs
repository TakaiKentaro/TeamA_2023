using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//����鑫��𐶐�����R���|�[�l���g
public class TimeGroundCreate : MonoBehaviour
{
    //����̃v���n�u
    [SerializeField] GameObject field;
    private TimeLimitGround tg;
    private float totalTime;
    private float timeInterval = 5f;

    void Start()
    {
        //��������
        tg = Instantiate(field, transform.position, Quaternion.identity).GetComponent<TimeLimitGround>();
    }


    void Update()
    {
        //���ꂪ�Ȃ������炷���ɐ��ݏo������莞�Ԃ������瑫����Đ�������
        if (tg == null)
        {
            totalTime += Time.deltaTime;
            if(timeInterval <= totalTime)
            {
                totalTime = 0;
                tg = Instantiate(field, transform.position, Quaternion.identity).GetComponent<TimeLimitGround>();
            }
        }
    }
}
