using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MurderMysteryUIController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject witnessPanel;
    public GameObject suspectPanel;
    public GameObject resultPanel;

    [Header("Start Screen")]
    public Button startButton;

    [Header("Witness Screen")]
    public TextMeshProUGUI witness1Text;
    public TextMeshProUGUI witness2Text;
    public TextMeshProUGUI witness3Text;
    public Button continueFromWitnessButton;

    [Header("Suspect Screen")]
    public Button suspect1Button;
    public Button suspect2Button;
    public Button suspect3Button;
    public Button suspect4Button;
    public Button suspect5Button;
    public TextMeshProUGUI suspect1NameText;
    public TextMeshProUGUI suspect2NameText;
    public TextMeshProUGUI suspect3NameText;
    public TextMeshProUGUI suspect4NameText;
    public TextMeshProUGUI suspect5NameText;
    [Header("Suspect Profile Images (Optional)")]
    [Tooltip("Image components to display suspect profile pictures. Leave empty if no images.")]
    public Image suspect1Image;
    public Image suspect2Image;
    public Image suspect3Image;
    public Image suspect4Image;
    public Image suspect5Image;

    [Header("Result Screen")]
    public TextMeshProUGUI resultTitleText;
    public TextMeshProUGUI resultExplanationText;
    public Image resultSuspectImage;
    [Tooltip("Image component to show the killer's profile picture on result screen. Optional.")]
    public Button playAgainButton;

    [Header("Game Manager Reference")]
    public GameManager gameManager;

    private SuspectData selectedSuspect;

    void Start()
    {
        // Debug: Check if panels are assigned
        if (startPanel == null)
            Debug.LogError("UIController: StartPanel is not assigned!");
        if (witnessPanel == null)
            Debug.LogError("UIController: WitnessPanel is not assigned!");
        if (suspectPanel == null)
            Debug.LogError("UIController: SuspectPanel is not assigned!");
        if (resultPanel == null)
            Debug.LogError("UIController: ResultPanel is not assigned!");

        // Initialize UI
        ShowStartScreen();

        // Setup button listeners
        if (startButton != null)
            startButton.onClick.AddListener(OnStartButtonClicked);
        else
            Debug.LogError("UIController: StartButton is not assigned!");

        if (continueFromWitnessButton != null)
            continueFromWitnessButton.onClick.AddListener(OnContinueFromWitnessClicked);

        if (suspect1Button != null)
            suspect1Button.onClick.AddListener(() => OnSuspectSelected(0));
        if (suspect2Button != null)
            suspect2Button.onClick.AddListener(() => OnSuspectSelected(1));
        if (suspect3Button != null)
            suspect3Button.onClick.AddListener(() => OnSuspectSelected(2));
        if (suspect4Button != null)
            suspect4Button.onClick.AddListener(() => OnSuspectSelected(3));
        if (suspect5Button != null)
            suspect5Button.onClick.AddListener(() => OnSuspectSelected(4));

        if (playAgainButton != null)
            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
    }

    public void ShowStartScreen()
    {
        HideAllPanels();
        if (startPanel != null)
            startPanel.SetActive(true);
    }

    public void ShowWitnessScreen()
    {
        HideAllPanels();
        if (witnessPanel != null)
        {
            witnessPanel.SetActive(true);
            UpdateWitnessTexts();
        }
    }

    public void ShowSuspectScreen()
    {
        HideAllPanels();
        if (suspectPanel != null)
        {
            suspectPanel.SetActive(true);
            UpdateSuspectNames();
        }
    }

    public void ShowResultScreen()
    {
        HideAllPanels();
        if (resultPanel != null)
        {
            resultPanel.SetActive(true);
            UpdateResultTexts();
        }
    }

    private void HideAllPanels()
    {
        if (startPanel != null) startPanel.SetActive(false);
        if (witnessPanel != null) witnessPanel.SetActive(false);
        if (suspectPanel != null) suspectPanel.SetActive(false);
        if (resultPanel != null) resultPanel.SetActive(false);
    }

    private void UpdateWitnessTexts()
    {
        if (gameManager == null || gameManager.caseSolver == null) return;

        var witnesses = gameManager.caseSolver.allWitnesses;

        if (witness1Text != null && witnesses.Count > 0)
        {
            var witness = witnesses[0];
            string reliability = GetReliabilityText(witness.GetReliability());
            witness1Text.text = $"Witness 1 (Age: {witness.age}, Reliability: {reliability})\n\n{witness.statement}";
        }

        if (witness2Text != null && witnesses.Count > 1)
        {
            var witness = witnesses[1];
            string reliability = GetReliabilityText(witness.GetReliability());
            witness2Text.text = $"Witness 2 (Age: {witness.age}, Reliability: {reliability})\n\n{witness.statement}";
        }

        if (witness3Text != null && witnesses.Count > 2)
        {
            var witness = witnesses[2];
            string reliability = GetReliabilityText(witness.GetReliability());
            witness3Text.text = $"Witness 3 (Age: {witness.age}, Reliability: {reliability})\n\n{witness.statement}";
        }
    }

    private string GetReliabilityText(WitnessReliability reliability)
    {
        switch (reliability)
        {
            case WitnessReliability.High:
                return "HIGH";
            case WitnessReliability.Medium:
                return "MEDIUM";
            case WitnessReliability.Low:
                return "LOW";
            default:
                return "UNKNOWN";
        }
    }

    private void UpdateSuspectNames()
    {
        if (gameManager == null || gameManager.caseSolver == null) return;

        var suspects = gameManager.caseSolver.allSuspects;

        // Update suspect 1
        if (suspects.Count > 0)
        {
            if (suspect1NameText != null)
                suspect1NameText.text = suspects[0].suspectName;
            if (suspect1Image != null)
            {
                if (suspects[0].profileImage != null)
                {
                    suspect1Image.sprite = suspects[0].profileImage;
                    suspect1Image.enabled = true;
                }
                else
                {
                    suspect1Image.enabled = false;
                }
            }
        }

        // Update suspect 2
        if (suspects.Count > 1)
        {
            if (suspect2NameText != null)
                suspect2NameText.text = suspects[1].suspectName;
            if (suspect2Image != null)
            {
                if (suspects[1].profileImage != null)
                {
                    suspect2Image.sprite = suspects[1].profileImage;
                    suspect2Image.enabled = true;
                }
                else
                {
                    suspect2Image.enabled = false;
                }
            }
        }

        // Update suspect 3
        if (suspects.Count > 2)
        {
            if (suspect3NameText != null)
                suspect3NameText.text = suspects[2].suspectName;
            if (suspect3Image != null)
            {
                if (suspects[2].profileImage != null)
                {
                    suspect3Image.sprite = suspects[2].profileImage;
                    suspect3Image.enabled = true;
                }
                else
                {
                    suspect3Image.enabled = false;
                }
            }
        }

        // Update suspect 4
        if (suspects.Count > 3)
        {
            if (suspect4NameText != null)
                suspect4NameText.text = suspects[3].suspectName;
            if (suspect4Image != null)
            {
                if (suspects[3].profileImage != null)
                {
                    suspect4Image.sprite = suspects[3].profileImage;
                    suspect4Image.enabled = true;
                }
                else
                {
                    suspect4Image.enabled = false;
                }
            }
        }

        // Update suspect 5
        if (suspects.Count > 4)
        {
            if (suspect5NameText != null)
                suspect5NameText.text = suspects[4].suspectName;
            if (suspect5Image != null)
            {
                if (suspects[4].profileImage != null)
                {
                    suspect5Image.sprite = suspects[4].profileImage;
                    suspect5Image.enabled = true;
                }
                else
                {
                    suspect5Image.enabled = false;
                }
            }
        }
    }

    private void UpdateResultTexts()
    {
        if (gameManager == null) return;

        bool isCorrect = gameManager.IsPlayerCorrect(selectedSuspect);
        SuspectData realKiller = gameManager.GetRealKiller();

        if (resultTitleText != null)
        {
            resultTitleText.text = isCorrect ? "CORRECT!" : "WRONG!";
            resultTitleText.color = isCorrect ? Color.green : Color.red;
        }

        // Update result image if available
        if (resultSuspectImage != null && realKiller != null)
        {
            if (realKiller.profileImage != null)
            {
                resultSuspectImage.sprite = realKiller.profileImage;
                resultSuspectImage.enabled = true;
            }
            else
            {
                resultSuspectImage.enabled = false;
            }
        }

        if (resultExplanationText != null)
        {
            string explanation = "";
            if (isCorrect)
            {
                explanation = $"Congratulations! You correctly identified {realKiller.suspectName} as the killer.\n\n";
            }
            else
            {
                explanation = $"You selected {selectedSuspect.suspectName}, but the real killer is {realKiller.suspectName}.\n\n";
            }

            explanation += $"The real killer was: {realKiller.suspectName}\n";
            explanation += $"Height: {realKiller.height}cm\n";
            explanation += $"Hair: {realKiller.hairColor}, {realKiller.hairLength}\n";
            explanation += $"Outfit: {realKiller.outfit}\n";
            explanation += $"Special Mark: {realKiller.specialMark}\n";
            explanation += $"Behavior: {realKiller.behavior}";

            resultExplanationText.text = explanation;
        }
    }

    private void OnStartButtonClicked()
    {
        ShowWitnessScreen();
    }

    private void OnContinueFromWitnessClicked()
    {
        ShowSuspectScreen();
    }

    private void OnSuspectSelected(int index)
    {
        if (gameManager == null || gameManager.caseSolver == null) return;

        var suspects = gameManager.caseSolver.allSuspects;
        if (index >= 0 && index < suspects.Count)
        {
            selectedSuspect = suspects[index];
            gameManager.OnSuspectSelected(selectedSuspect);
            ShowResultScreen();
        }
    }

    private void OnPlayAgainClicked()
    {
        selectedSuspect = null;
        ShowStartScreen();
    }
}

