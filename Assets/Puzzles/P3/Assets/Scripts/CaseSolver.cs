using System.Collections.Generic;
using UnityEngine;

public class CaseSolver : MonoBehaviour
{
    [Header("Case Data")]
    public List<SuspectData> allSuspects = new List<SuspectData>();
    public List<WitnessData> allWitnesses = new List<WitnessData>();
    
    [Header("Scoring Weights")]
    public float heightMatchWeight = 1.0f;
    public float outfitMatchWeight = 1.0f;
    public float specialMarkWeight = 3.0f; // Higher weight for special marks
    public float reliabilityHighWeight = 3.0f;
    public float reliabilityMediumWeight = 2.0f;
    public float reliabilityLowWeight = 1.0f;
    
    private Dictionary<SuspectData, float> suspectScores = new Dictionary<SuspectData, float>();
    
    public void CalculateScores()
    {
        suspectScores.Clear();
        
        // Initialize all suspect scores to 0
        foreach (var suspect in allSuspects)
        {
            suspectScores[suspect] = 0f;
        }
        
        // Evaluate each witness statement
        foreach (var witness in allWitnesses)
        {
            float reliabilityWeight = GetReliabilityWeight(witness.GetReliability());
            
            foreach (var suspect in allSuspects)
            {
                float score = EvaluateSuspectAgainstWitness(suspect, witness, reliabilityWeight);
                suspectScores[suspect] += score;
            }
        }
    }
    
    private float GetReliabilityWeight(WitnessReliability reliability)
    {
        switch (reliability)
        {
            case WitnessReliability.High:
                return reliabilityHighWeight;
            case WitnessReliability.Medium:
                return reliabilityMediumWeight;
            case WitnessReliability.Low:
                return reliabilityLowWeight;
            default:
                return 1.0f;
        }
    }
    
    private float EvaluateSuspectAgainstWitness(SuspectData suspect, WitnessData witness, float reliabilityWeight)
    {
        float score = 0f;
        
        // Check height match
        if (witness.minHeight > 0 || witness.maxHeight > 0)
        {
            if (suspect.height >= witness.minHeight && suspect.height <= witness.maxHeight)
            {
                score += heightMatchWeight * reliabilityWeight;
            }
            else
            {
                // Height mismatch - decrease score
                score -= heightMatchWeight * reliabilityWeight * 0.5f;
            }
        }
        
        // Check outfit match
        if (!string.IsNullOrEmpty(witness.outfitColor))
        {
            string suspectOutfitLower = suspect.outfit.ToLower();
            string witnessOutfitLower = witness.outfitColor.ToLower();
            
            // Check for color matches (dark = black, dark green, etc.)
            bool matches = false;
            if (witnessOutfitLower == "dark")
            {
                matches = suspectOutfitLower.Contains("black") || 
                         suspectOutfitLower.Contains("dark") ||
                         suspectOutfitLower.Contains("gray") ||
                         suspectOutfitLower.Contains("grey");
            }
            else
            {
                matches = suspectOutfitLower.Contains(witnessOutfitLower) || 
                         witnessOutfitLower.Contains(suspectOutfitLower);
            }
            
            if (matches)
            {
                score += outfitMatchWeight * reliabilityWeight;
            }
            else
            {
                // Outfit mismatch - decrease score (less penalty for low reliability witnesses)
                float penalty = reliabilityWeight == reliabilityLowWeight ? 0.3f : 0.5f;
                score -= outfitMatchWeight * reliabilityWeight * penalty;
            }
        }
        
        // Check special mark match (higher weight)
        if (!string.IsNullOrEmpty(witness.specialMarkMentioned))
        {
            string suspectMarkLower = suspect.specialMark.ToLower();
            string witnessMarkLower = witness.specialMarkMentioned.ToLower();
            
            // Flexible matching for special marks
            bool matches = false;
            if (witnessMarkLower.Contains("tattoo"))
            {
                matches = suspectMarkLower.Contains("tattoo");
            }
            else if (witnessMarkLower.Contains("watch"))
            {
                matches = suspectMarkLower.Contains("watch");
            }
            else if (witnessMarkLower.Contains("mole"))
            {
                matches = suspectMarkLower.Contains("mole");
            }
            else
            {
                matches = suspectMarkLower.Contains(witnessMarkLower) || 
                         witnessMarkLower.Contains(suspectMarkLower);
            }
            
            if (matches)
            {
                score += specialMarkWeight * reliabilityWeight;
            }
            else if (!string.IsNullOrEmpty(suspect.specialMark))
            {
                // Has a special mark but doesn't match - slight decrease
                // Less penalty for low reliability "maybe" statements
                float penalty = reliabilityWeight == reliabilityLowWeight ? 0.1f : 0.3f;
                score -= specialMarkWeight * reliabilityWeight * penalty;
            }
        }
        
        return score;
    }
    
    public SuspectData GetKiller()
    {
        SuspectData killer = null;
        float highestScore = float.MinValue;
        
        foreach (var kvp in suspectScores)
        {
            if (kvp.Value > highestScore)
            {
                highestScore = kvp.Value;
                killer = kvp.Key;
            }
        }
        
        return killer;
    }
    
    public float GetSuspectScore(SuspectData suspect)
    {
        if (suspectScores.ContainsKey(suspect))
            return suspectScores[suspect];
        return 0f;
    }
    
    public Dictionary<SuspectData, float> GetAllScores()
    {
        return new Dictionary<SuspectData, float>(suspectScores);
    }
}

