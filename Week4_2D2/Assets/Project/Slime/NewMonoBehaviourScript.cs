using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 10.0f;
    Animator slime;
    void Start()
    {
        slime = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = speed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") >= 0.25)
            slime.SetBool("left",true);
        else
            slime.SetBool("left",false);

    }
}
