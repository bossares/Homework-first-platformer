using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _minForce = 0.25f;
    [SerializeField] private float _maxForce = 15f;
    [SerializeField] private float _maxInputHoldTimeDuration = 0.8f;
    private float _force;
    private Coroutine _increaseForceCoroutine;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _playerInput.Player.Jump.started += ctx => OnJumpStarted();
        _playerInput.Player.Jump.performed += ctx => OnJump();
        _playerInput.Player.Jump.canceled += ctx => OnJump();
        _force = _minForce;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Jump.started -= ctx => OnJumpStarted();
        _playerInput.Player.Jump.performed -= ctx => OnJump();
        _playerInput.Player.Jump.canceled -= ctx => OnJump();
    }
    
    private void OnJumpStarted()
    {
        _increaseForceCoroutine = StartCoroutine(IncreaseForce());
    }

    private void OnJump()
    {
        StopCoroutine(_increaseForceCoroutine);
        Jump();
        _force = _minForce;
    }

    private IEnumerator IncreaseForce()
    {
        float maxInputHoldTimeDivider = 10;
        float delay = _maxInputHoldTimeDuration / maxInputHoldTimeDivider;
        WaitForSeconds waitTime = new WaitForSeconds(delay);
        float increaseStep = (_maxForce - _minForce) / maxInputHoldTimeDivider;

        while (_force < _maxForce)
        {
            _force += increaseStep;
            yield return waitTime;
        }
    }

    private void Jump()
    {
        if (_player.IsOnGround && _player.Health.Value > 0)
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }
    }
}
