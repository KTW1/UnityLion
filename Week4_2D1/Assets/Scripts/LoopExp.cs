using UnityEngine;

public class LoopExp : MonoBehaviour
{
    void Start()
    {
        for (int y = 0; y <= 10; y++)
        {
            Debug.Log("Count " + y);
        }

        int counter = 0;
        while (counter < 5)
        {
            Debug.Log("While Count: " + counter);
            counter++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
