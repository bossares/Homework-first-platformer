using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CollectStars))]
public class Player : MonoBehaviour
{
    [SerializeField] Ground _ground;

    private Animator _animator;
    private Health _health;
    private CollectStars _collectStars;

    public bool IsOnGround { get; private set; }

    public Health Health => _health;
    public CollectStars Stars => _collectStars;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _collectStars = GetComponent<CollectStars>();
    }

    private void OnEnable()
    {
        _health.IsOver += OnDie;
        _health.IsTakeDamage += OnTakeDamage;
        _ground.IsGrounded += OnGrounded;
    }

    private void OnDisable()
    {
        _health.IsOver -= OnDie;
        _health.IsTakeDamage -= OnTakeDamage;
        _ground.IsGrounded -= OnGrounded;
    }

    private void OnTakeDamage()
    {
        _animator.SetTrigger("takeDamage");
    }

    private void OnDie()
    {
        _animator.SetBool("isDeath", true);
    }

    private void OnGrounded(bool value)
    {
        IsOnGround = value;
        _animator.SetBool("isOnGround", value);
    }
}
