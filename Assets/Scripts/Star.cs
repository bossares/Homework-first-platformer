using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Star : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Vector3 _defaultScale = new Vector3(5, 5, 0);
    private Color _defaultColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
            ResetParameters();
            player.Stars.Take();
        }
    }

    private void ResetParameters()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = _defaultScale;
        _spriteRenderer.color = _defaultColor;
    }
}
