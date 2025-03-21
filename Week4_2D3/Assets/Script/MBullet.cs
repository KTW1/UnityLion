using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        //��ȯ ��ȯ �Ʒ�. ���ǵ�. ��ŸŸ��
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹��. �±� Player
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject) ;
        }
    }
}
