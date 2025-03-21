using UnityEngine;

public class Item : MonoBehaviour
{
    //������ ���� �ӵ�
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
