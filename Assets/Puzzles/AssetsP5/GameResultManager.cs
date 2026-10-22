using UnityEngine;

public class GameResultManager : MonoBehaviour
{
    public static GameResultManager Instance;

    // 100 = win , 0 = lose , -1 = not finished yet
    public int result = -1;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetWin()
    {
        result = 100;
        Debug.Log("MINI GAME RESULT: 100 (WIN)");
    }

    public void SetLose()
    {
        result = 0;
        Debug.Log("MINI GAME RESULT: 0 (LOSE)");
    }
}
