using UnityEngine;
using IJunior.TypedScenes;
using System.Collections;

[RequireComponent(typeof(Health))]
public class GameOver : MonoBehaviour
{
    [SerializeField] float _backToMenuDelay = 3f;

    private Health _playerHealth;
    private WaitForSeconds _waitTime;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _waitTime = new WaitForSeconds(_backToMenuDelay);
    }

    private void OnEnable()
    {
        _playerHealth.Ended += OnPlayerDie;
    }

    private void OnDisable()
    {
        _playerHealth.Ended -= OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        StartCoroutine(nameof(ReturnToGameMenu));
    }

    private IEnumerator ReturnToGameMenu()
    {
        yield return _waitTime;
        Menu.Load();
    }
}
