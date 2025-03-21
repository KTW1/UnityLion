using UnityEngine;

public class Func : MonoBehaviour
{
    void Start()
    {
        SayHello();
        int total = AddNumbers(3, 5);
        Debug.Log("Sum? " + total);

        void SayHello()
        {
            Debug.Log("Function");
        }
        int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
    void Update()
    {
        
    }
}
