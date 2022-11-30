using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _maxSpeed = 5f;

    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;
    private Player _player;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float _direction;
    private float _absoluteSpeed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        _direction = _playerInput.Player.Move.ReadValue<float>();
        _absoluteSpeed = Math.Abs(_rigidbody2D.velocity.x);

        if (_player.Health.Value > 0)
        {
            LookToMoveDirection();
            Move();
        }
    }

    private void LookToMoveDirection()
    {
        if (_direction != 0)
            _spriteRenderer.flipX = _direction < 0;
    }

    private void Move()
    {
        if (_player.IsOnGround && _absoluteSpeed < _maxSpeed)
            _rigidbody2D.AddForce(new Vector2(_direction * _speed * Time.deltaTime, 0), ForceMode2D.Impulse);

        _animator.SetFloat(AnimatorPlayerController.Params.Speed, _absoluteSpeed);
    }
}
