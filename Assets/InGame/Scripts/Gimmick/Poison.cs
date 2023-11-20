using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary> �M�~�b�N�F�ł̋��� </summary>
public class Poison : WaterGimmickBase
{
    [SerializeField, Tooltip("Player�ɗ^����_���[�W")]
    float _damageSizeToPlayer = 0f;
    Collider2D _collider = default;
    Animator _poisonAnim = default;
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = false;
        _poisonAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player�����������Ƃ��Ƀ_���[�W�^����
        if (collision.gameObject.TryGetComponent<PlayerHp>(out var playerHp))
        {
            playerHp.ApplyDamage(_damageSizeToPlayer, Vector2.zero).Forget();
        }
    }

    public override void WeightActive()
    {
        //�ł������Ēʂ��悤�ɂȂ�
        _poisonAnim.SetBool("IsAttacked", true);
    }
}
