using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public int Value => _health;

    public event UnityAction IsOver;
    public event UnityAction IsTakeDamage;

    private void Update()
    {
        if (_health <= 0)
            IsOver?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        IsTakeDamage?.Invoke();

        if (_health > 0)
            _health -= damage;
    }
}
