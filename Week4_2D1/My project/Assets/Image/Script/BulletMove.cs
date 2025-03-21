using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 2.0f;
    public GameObject exposion;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) //enter&Exit
    {
        //if(collision.gameObject.tag == "Enemy") //�浹�� ������Ʈ�� �±װ� Enemy���
        if(collision.gameObject.CompareTag("Enemy")) //������?
        {
            SoundManage.Instance.SoundDie();
            
            Destroy(collision.gameObject); //�����Ѵ�.
            Destroy(gameObject); //�Ѿ� ����.
            GameManage.instance.AddScore(10); //uI���ھ�+������ȯ
            Instantiate(exposion, transform.position, Quaternion.identity);
        }
    }

}
