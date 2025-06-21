using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _particleSystem != null)
        {
            _particleSystem.Play();
            _spriteRenderer.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
