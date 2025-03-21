using UnityEngine;

public class Player
{
    string name;
    int score;

    public Player(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
    public void ShowInfo()
    {
        Debug.Log("Player : " + name + ", Score : " + score);
    }
}
public class Class : MonoBehaviour
{
    void Start()
    {
        Player player1 = new Player("Hero", 10);
        player1.ShowInfo();
    }

    void Update()
    {
        
    }
}
