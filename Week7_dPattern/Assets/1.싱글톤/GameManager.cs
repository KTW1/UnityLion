using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager prinstance;
    public static GameManager Instance
    {
        get
        {
            if(prinstance == null)
            {
                prinstance = FindFirstObjectByType<GameManager>();
                if(prinstance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    prinstance = singletonObject.AddComponent<GameManager>();
                }
            }
            return prinstance;
        }
    }
    
    private void Awake()
    {
        if(prinstance != null && prinstance != this)
        {
            Destroy(gameObject);
            return;
        }
        prinstance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int _score = 0;
    public int Score => _score;
    public void AddScore(int points)
    {
        _score += points;
        Debug.Log($"Score updated: {_score}");
    }
}
