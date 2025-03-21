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
    //전역오브젝트 bullet
    public Transform pos = null;
    public Image Gage;

    //전역 변환 pos null값
    public int p=0;
    [SerializeField] //이게 없으면? 인스펙터창에 생성이 안된다.
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
        
        //조건. 입력.다운키.키코드.스페이스 
        if (Input.GetKeyDown(KeyCode.Space)) //KeyDown 누를 때마다 출력
        {
            Instantiate(Bullet[p], pos.position, Quaternion.identity);
        }
        //생성한다 불렛 프리팹, 포지션, 회전은 안함
        else if (Input.GetKey(KeyCode.Space)) //KeyDown 누를 때마다 출력
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
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.

    }
}
