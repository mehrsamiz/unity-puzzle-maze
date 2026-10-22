using UnityEngine;
using UnityEngine.UI;
using TMPro; // If using TextMeshPro

public class MurderMysteryController : MonoBehaviour
{
    [Header("UI Components")]
    public Image mainDisplayImage;       // The image component that changes
    public GameObject witnessPanel;      // Holds the witness texts and the button
    public GameObject suspectPanel;      // Holds the 5 suspect buttons
    public GameObject feedbackPanel;     // Optional: To show Win/Lose result
    public TextMeshProUGUI feedbackText; // Optional: Text for Win/Lose

    [Header("Assets")]
    public Sprite introSprite;           // Drag your Intro image here
    public Sprite questionSprite;        // Drag your Question image here

    [Header("Suspect Buttons")]
    public Button[] suspectButtons;      // Array to hold the 5 suspect buttons

    // State tracking
    private int clickState = 0;
    // 0 = Intro, 1 = Question, 2 = Witnesses, 3 = Suspects

    void Start()
    {
        // specific setup based on your requirements
        clickState = 0;

        // 1. Show Intro Image initially
        mainDisplayImage.sprite = introSprite;
        mainDisplayImage.gameObject.SetActive(true);

        // Hide other panels
        witnessPanel.SetActive(false);
        suspectPanel.SetActive(false);
        if (feedbackPanel) feedbackPanel.SetActive(false);

        // Add click listener to the Main Image
        // We use a button component on the image or an EventTrigger, 
        // but adding a Button component to the Image object is easiest.
        Button imgBtn = mainDisplayImage.GetComponent<Button>();
        if (imgBtn == null) imgBtn = mainDisplayImage.gameObject.AddComponent<Button>();
        imgBtn.onClick.AddListener(OnMainImageClicked);

        // Setup Suspect Buttons listeners
        for (int i = 0; i < suspectButtons.Length; i++)
        {
            int index = i; // Local copy for closure
            suspectButtons[i].onClick.AddListener(() => OnSuspectClicked(index));
        }
    }

    // Handles clicking the main image (Intro -> Question -> Witnesses)
    void OnMainImageClicked()
    {
        if (clickState == 0)
        {
            // Transition: Intro -> Question
            mainDisplayImage.sprite = questionSprite;
            clickState = 1;
        }
        else if (clickState == 1)
        {
            // Transition: Question -> Witnesses
            mainDisplayImage.gameObject.SetActive(false); // Hide the image
            witnessPanel.SetActive(true);                 // Show text/witnesses
            clickState = 2;
        }
    }

    // Linked to the button inside the Witness Panel
    public void GoToSuspects()
    {
        witnessPanel.SetActive(false);
        suspectPanel.SetActive(true);
        clickState = 3;
    }

    // Logic for checking the correct suspect (Sara Nikpour is Suspect 1)
    void OnSuspectClicked(int suspectIndex)
    {
        // Based on the Witness logic: Sara Nikpour (Index 0) is the killer.
        bool isCorrect = (suspectIndex == 0);

        if (feedbackPanel) feedbackPanel.SetActive(true);

        if (isCorrect)
        {
            Debug.Log("Correct! Sara Nikpour matches the description.");
            if (feedbackText) feedbackText.text = "Correct! Sara matches the description.";

            // --- CONNECTION TO BASE GAME ---
            // Success: +60 points and Destroy Wall
            PuzzleManager.Instance.OnPuzzleComplete(true);
        }
        else
        {
            Debug.Log("Wrong suspect.");
            if (feedbackText) feedbackText.text = "Wrong! Review the witness reliability.";

            // --- CONNECTION TO BASE GAME ---
            // Failure: -10 points and Close UI
            PuzzleManager.Instance.OnPuzzleComplete(false);
        }
    }
}