using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    public event UnityAction<bool> IsGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<Player>(out Player player))
            IsGrounded?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<Player>(out Player player))
            IsGrounded?.Invoke(false);
    }
}
