using UnityEngine;

public class variableExample : MonoBehaviour
{
    public int playerScore = 0;
    public float speed = 5.5f;
    public string playerName = "Hero";
    public bool isGameOver = false;
    public int health = 100;

    void Start()
    {
        Debug.Log("Player Name : " + playerName);
        Debug.Log("Player Score : " + playerScore);
        Debug.Log("Speed : " + speed);
        Debug.Log("Is Game Over? : " + isGameOver);
    }
    void Update()
    {
        health -= 1;
        Debug.Log("?"+health);
        if (health <= 0)
        {
            Debug.Log("End");
        }
    }
}
