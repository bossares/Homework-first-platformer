using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BatAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            player.Health.TakeDamage(_damage);
    }
}
