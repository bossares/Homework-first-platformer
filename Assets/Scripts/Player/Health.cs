using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public int Value => _health;

    public event UnityAction Ended;
    public event UnityAction Damaged;

    public void TakeDamage(int damage)
    {
        Damaged?.Invoke();

        if (_health > 0)
            _health -= damage;

        if (_health <= 0)
            Ended?.Invoke();
    }
}
