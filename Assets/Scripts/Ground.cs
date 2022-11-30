using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    public event UnityAction<bool> Grounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<Player>(out Player player))
            Grounded?.Invoke(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<Player>(out Player player))
            Grounded?.Invoke(false);
    }
}
