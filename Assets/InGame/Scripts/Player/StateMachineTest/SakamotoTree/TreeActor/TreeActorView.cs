using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeActorView : MonoBehaviour
{
    [Header("Time��RectTransform")]
    [SerializeField] RectTransform _rectCurrent;
    [Tooltip("Time�o�[�Œ��̒���")]
    private float _maxHpWidth;
    [Tooltip("Time�o�[�̍ő�l")]
    private float _maxHp;

    void Awake()
    {
        _maxHpWidth = _rectCurrent.sizeDelta.x;
    }

    public void SetMaxHp(float Maxhp)
    {
        _maxHp = Maxhp;
    }

    public void SetHpCurrent(float currentHp)
    {
        //�o�[�̒������X�V
        //_rectCurrent.SetWidth(GetWidth(currentHp));
        if (currentHp < 0)
        {
            Debug.Log("�ۂ[��");
        }
    }


    private float GetWidth(float value)
    {
        float width = Mathf.InverseLerp(0, _maxHp, value);
        return Mathf.Lerp(0, _maxHpWidth, width);
    }
}
