using UnityEngine;

public class Pl : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.25f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.25f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.25f)
            ani.SetBool("Up", true);
        else
            ani.SetBool("Up", false);

        //if (Input.GetAxis("Vertical") >= 0.5f)
        //    ani.SetBool("up", true);
        //else
        //    ani.SetBool("up", false);

        transform.Translate(moveX, moveY, 0);

    }
}