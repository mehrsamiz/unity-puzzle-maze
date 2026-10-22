using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Q2Manager : MonoBehaviour
{
    public TMP_InputField answerInput;
    public TMP_Text resultText;
    public Button submitButton;

    [Header("Puzzle Settings")]
    public int correctAnswer = 13;
    private int attempts = 0; // شمارنده تلاش‌ها
    private bool isSolved = false;

    public void CheckAnswer()
    {
        if (isSolved) return;

        int playerAnswer;
        if (!int.TryParse(answerInput.text, out playerAnswer))
        {
            resultText.text = "Please enter a number.";
            return;
        }

        attempts++; // اضافه کردن به تعداد تلاش‌ها

        if (playerAnswer == correctAnswer)
        {
            isSolved = true;
            resultText.text = "Correct!";
            resultText.color = Color.green;

            // فراخوانی متد جدید برای محاسبه امتیاز متغیر
            ApplyVariableScore();
        }
        else
        {
            resultText.text = "Wrong! Try again.";
            resultText.color = Color.red;

            //[cite_start]// کسر ۱۰ امتیاز بابت اشتباه طبق قانون 
            ScoreManager.Instance.DeductPuzzleFail();

            answerInput.text = ""; // پاک کردن ورودی برای تلاش بعدی
        }
    }

    private void ApplyVariableScore()
    {
        //[cite_start]// امتیاز پایه طبق فایل پروژه ۶۰ است 
        int finalReward = 60;

        // اگر تلاش اول نبود، امتیاز نصف می‌شود (30)
        if (attempts > 1)
        {
            finalReward = 30;
        }

        // ارسال امتیاز محاسبه شده به ScoreManager
        // نکته: باید یک متد در ScoreManager داشته باشید که مقدار ورودی بگیرد
        ScoreManager.Instance.AddCustomScore(finalReward);

        // بستن پازل و حذف دیوار از طریق مدیر پازل
        PuzzleManager.Instance.OnPuzzleComplete(true);
    }
}