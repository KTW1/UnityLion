using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        transform.Translate(distanceX, 0, 0);
        transform.Translate(0, distanceY, 0);

        //1�� ��ǥ�� �ӵ��� ����� �̵�. 2�� ������ ����
    }
}
