using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5.1f;

    void Start()
    {
        
    }

    void Update()
    {
        //float axis = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.right * axis * speed * Time.deltaTime);
        //transform.Translate(Vector3.up * ver * speed * Time.deltaTime);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
}
