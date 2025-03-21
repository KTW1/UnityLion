using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float JumpUp = 1f;
    public Vector3 dir;
    bool bJump = false;

    public GameObject slash;
    Animator Ani;
    Rigidbody2D rig;
    SpriteRenderer Sp;
    void Start()
    {
        Ani = GetComponent<Animator>();
        dir = Vector2.zero;
        rig = GetComponent<Rigidbody2D>();
        Sp = GetComponent<SpriteRenderer>();
    }

    void KeyInput()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(dir.x, 0) * speed * Time.deltaTime);

        if (dir.x < 0)
        {
            Sp.flipX = true;
            Ani.SetBool("Run",true);
        }
        else if(dir.x > 0)
        {
            Sp.flipX = false;
            Ani.SetBool("Run", true);
        }
        else if(dir.x == 0)
        {
            Ani.SetBool("Run", false);
        }
    }

    void Update()
    {
        KeyInput();
        Move();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Ani.GetBool("Jump") == false)
            {
                Jump();
                Ani.SetBool("Jump", true);
            }

        }
    }
    public void Jump()
    {
        rig.linearVelocity = Vector2.zero;
        rig.AddForce(new Vector2(0, JumpUp), ForceMode2D.Impulse);

    }


    private void FixedUpdate()
    {
        Debug.DrawRay(rig.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rig.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rig.linearVelocityY < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    Ani.SetBool("Jump", false);
                }
            }
        }
        if (Input.GetMouseButtonDown(0)) //0번 왼쪽마우스
        {
            Ani.SetTrigger("Attack");
        }
    }


    public void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    public void Attack()
    {
        Instantiate(slash, transform.position, Quaternion.identity);
    }
}
