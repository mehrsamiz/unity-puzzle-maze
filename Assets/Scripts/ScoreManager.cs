
using UnityEngine;
using TMPro; // Use this if you are using TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Game Settings")]
    public int currentScore = 2000;
    public int bonusScore = 0;
    public int maxScore = 2000;

    // Optional: Drag your UI Text here in the Inspector
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Singleton pattern to access this from GridLogic
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    // --- SCORING METHODS ---

    // 1. Standard Move (-10)
    public void DeductMoveCost()
    {
        ModifyScore(-10);
    }

    // 2. Yellow Penalty (-10 extra)
    public void DeductYellowPenalty()
    {
        ModifyScore(-10);
    }

    // 3. Red Penalty (-30 extra)
    public void DeductRedPenalty()
    {
        ModifyScore(-30);
    }

    // 4. Puzzle Success (+60)
    public void AddPuzzleSuccess()
    {
        int points = 60;

        // Logic: Score is capped at 2000. Excess goes to Bonus.
        if (currentScore + points > maxScore)
        {
            int overflow = (currentScore + points) - maxScore;
            currentScore = maxScore;
            bonusScore += overflow;
        }
        else
        {
            currentScore += points;
        }
        UpdateUI();
    }

    // 5. Puzzle Fail (-10)
    public void DeductPuzzleFail()
    {
        ModifyScore(-10);
    }

    // --- HELPER METHODS ---

    private void ModifyScore(int amount)
    {
        currentScore += amount;

        // Optional: prevent negative score
        if (currentScore < 0) currentScore = 0;

        UpdateUI();
    }

    // 6. Game Over / Win Method (+2000)
    public void FinishGame()
    {
        // Add the finish bonus
        if (currentScore + 2000 > maxScore)
        {
            int overflow = (currentScore + 2000) - maxScore;
            currentScore = maxScore;
            bonusScore += overflow;
        }
        else
        {
            currentScore += 2000;
        }

        CalculateRank();
    }

    private void CalculateRank()
    {
        //[cite_start]// Total Score Calculation [cite: 259]
        // The PDF implies Bonus is added to Final, but max is 4000
        int finalTotal = currentScore + bonusScore;

        string rank = "C";
        if (finalTotal >= 3750) rank = "S";      // [cite: 261]
        else if (finalTotal >= 3650) rank = "A"; // [cite: 262]
        else if (finalTotal >= 3400) rank = "B"; // [cite: 263]

        Debug.Log($"GAME OVER! Total Score: {finalTotal} | Rank: {rank}");
        if (scoreText != null) scoreText.text = $"Rank: {rank}\nFinal Score: {finalTotal}";
    }

    private void UpdateUI()
    {
        // Logs to console so you can see it working without UI
        Debug.Log($"Score: {currentScore} | Bonus: {bonusScore}");

        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore} \nBonus: {bonusScore}";
        }
    }

 
    public void AddCustomScore(int points)
    {
     
        if (currentScore + points > maxScore)
        {
            int overflow = (currentScore + points) - maxScore;
            currentScore = maxScore;
            bonusScore += overflow;
        }
        else
        {
            currentScore += points;
        }
        UpdateUI();
    }


}