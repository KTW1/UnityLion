using Unity.VisualScripting;
using UnityEngine;

public class pBullet : MonoBehaviour
{
    //���� �Ǽ��� Speed ���� 4
    public float Speed = 4.0f;
    public GameObject effect;
    public GameObject Item;
    public int Attack = 10;
    void Start()
    {
        
    }

    void Update()
    {
        //��ȯ ��ȯ Vector2 ��, �ӵ�, ��ŸŸ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //����� �Լ� Ʈ����2d. �ݸ��� �浹��
    //�±� ���� �浹��. ����.�浹/����. �̻��ϻ���
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 1f);
            GameObject power = Instantiate(Item, transform.position, Quaternion.identity);
            Destroy(power, 10f);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            //�浹��. ������Ʈ��.������Ʈ Monater��. ������ ȣ��
            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }

        if (collision.CompareTag("Boss"))
        {

            //����Ʈ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1�ʵڿ� �����
            Destroy(go, 1);

            //�̻��� ����
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        //�ı� ������Ʈ
        Destroy(gameObject);
    }

}
