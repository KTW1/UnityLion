using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed = 2.0f;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float Y = Speed * Time.deltaTime;
        transform.Translate(0, -Y, 0);
    }
    private void OnBecameInvisible() //ī�޶� �����ΰ��� ȣ��
    {
        Destroy(gameObject); //��ü ����
    }
}
