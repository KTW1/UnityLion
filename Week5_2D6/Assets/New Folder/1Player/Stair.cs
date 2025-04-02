using UnityEngine;

public class Stair : MonoBehaviour
{
    public GameObject Player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
