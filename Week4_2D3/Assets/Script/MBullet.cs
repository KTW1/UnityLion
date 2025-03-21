using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        //변환 전환 아래. 스피드. 델타타임
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌시. 태그 Player
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject) ;
        }
    }
}
