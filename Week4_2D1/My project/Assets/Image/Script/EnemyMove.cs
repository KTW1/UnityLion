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
    private void OnBecameInvisible() //카메라 밖으로가면 호출
    {
        Destroy(gameObject); //객체 삭제
    }
}
