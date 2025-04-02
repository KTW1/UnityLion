using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public float Detection = 5f;
    public float Interval = 2f;
    public GameObject Bullet;

    [Header("RefComponent")]
    public Transform FirePoint;
    public Transform player;
    private float timer;
    public SpriteRenderer SR;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SR = GetComponent<SpriteRenderer>();
        timer = Interval;
    }

    void Update()
    {
        if (player == null) return; //예외처리
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= Detection)
        {
            SR.flipX = player.position.x < transform.position.x;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = Interval;
                Fire();
            }
        } 
    }
    void Fire()
    {
        GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
        Vector2 dir = (player.position - FirePoint.position).normalized;
        bullet.GetComponent<mBullet>().SetDirection(dir);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Detection);
    }
    
    public void die()
    {
        animator.SetBool("Death", true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
