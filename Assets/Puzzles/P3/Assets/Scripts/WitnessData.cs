using UnityEngine;

[CreateAssetMenu(fileName = "New Witness", menuName = "Murder Mystery/Witness Data")]
public class WitnessData : ScriptableObject
{
    [Header("Witness Information")]
    public int age;
    public string statement;
    
    [Header("Clues Mentioned")]
    public int minHeight;
    public int maxHeight;
    public string outfitColor;
    public string specialMarkMentioned;
    
    public WitnessReliability GetReliability()
    {
        if (age >= 20 && age <= 30)
            return WitnessReliability.High;
        else if (age > 30 && age <= 55)
            return WitnessReliability.Medium;
        else
            return WitnessReliability.Low;
    }
}

public enum WitnessReliability
{
    Low,
    Medium,
    High
}

