using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Animator ani;

    public GameObject Lazer;
    private float PTime = 0f;
    
    public GameObject[] Bullet;
    //����������Ʈ bullet
    public Transform pos = null;
    public Image Gage;

    //���� ��ȯ pos null��
    public int p=0;
    [SerializeField] //�̰� ������? �ν�����â�� ������ �ȵȴ�.
    private GameObject powerup;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            p += 1;
            if (p >= 3)
                p = 3;
            else
            {
                GameObject go = Instantiate(powerup, transform.position, Quaternion.identity);
                Destroy(go, 1);

            }
            Destroy(collision.gameObject);  
        }
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);


        if(Input.GetAxis("Vertical")>=0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }
        
        //����. �Է�.�ٿ�Ű.Ű�ڵ�.�����̽� 
        if (Input.GetKeyDown(KeyCode.Space)) //KeyDown ���� ������ ���
        {
            Instantiate(Bullet[p], pos.position, Quaternion.identity);
        }
        //�����Ѵ� �ҷ� ������, ������, ȸ���� ����
        else if (Input.GetKey(KeyCode.Space)) //KeyDown ���� ������ ���
        {
            PTime += Time.deltaTime;
            Gage.fillAmount = PTime;

            if (PTime >= 2)
            {
                GameObject keep = Instantiate(Lazer, pos.position, Quaternion.identity);
                Destroy(keep, 2);
                PTime = 0;
            }
        }
        else
        {
            PTime -= Time.deltaTime;

            if (PTime <= 0)
            {
                PTime = 0;
            }


        }

        transform.Translate(moveX, moveY, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.

    }
}
