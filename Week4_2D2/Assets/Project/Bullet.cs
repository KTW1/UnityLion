using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
