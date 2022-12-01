using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private Animator _animator;
    private Health _health;
    private StarsCollector _collectStars;

    public bool IsOnGround { get; private set; }

    public Health Health => _health;
    public StarsCollector Stars => _collectStars;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _collectStars = GetComponent<StarsCollector>();
    }

    private void OnEnable()
    {
        _health.Ended += OnDie;
        _health.Damaged += OnTakeDamage;
        _ground.Grounded += OnGrounded;
    }

    private void OnDisable()
    {
        _health.Ended -= OnDie;
        _health.Damaged -= OnTakeDamage;
        _ground.Grounded -= OnGrounded;
    }

    private void OnTakeDamage()
    {
        _animator.SetTrigger(AnimatorPlayerController.Params.TakeDamage);
    }

    private void OnDie()
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsDeath, true);
    }

    private void OnGrounded(bool value)
    {
        IsOnGround = value;
        _animator.SetBool(AnimatorPlayerController.Params.IsOnGround, value);
    }
}
