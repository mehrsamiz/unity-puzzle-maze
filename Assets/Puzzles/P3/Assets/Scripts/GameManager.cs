using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Case Solver")]
    public CaseSolver caseSolver;
    
    [Header("UI Controller")]
    public MurderMysteryUIController uiController;
    
    private SuspectData realKiller;
    private SuspectData playerSelection;
    
    void Start()
    {
        // Calculate scores when game starts
        if (caseSolver != null)
        {
            caseSolver.CalculateScores();
            realKiller = caseSolver.GetKiller();
            
            // Debug: Print all scores
            Debug.Log("=== SUSPECT SCORES ===");
            var allScores = caseSolver.GetAllScores();
            foreach (var kvp in allScores)
            {
                Debug.Log($"{kvp.Key.suspectName}: {kvp.Value:F2}");
            }
            Debug.Log($"Real Killer: {realKiller.suspectName}");
        }
    }
    
    public void OnSuspectSelected(SuspectData suspect)
    {
        playerSelection = suspect;
    }
    
    public bool IsPlayerCorrect(SuspectData selectedSuspect)
    {
        if (selectedSuspect == null || realKiller == null)
            return false;
        
        return selectedSuspect == realKiller;
    }
    
    public SuspectData GetRealKiller()
    {
        return realKiller;
    }
}

