using UnityEngine;

[CreateAssetMenu(fileName = "New Suspect", menuName = "Murder Mystery/Suspect Data")]
public class SuspectData : ScriptableObject
{
    [Header("Basic Information")]
    public string suspectName;
    public int height;

    [Header("Appearance")]
    public string hairColor;
    public string hairLength;
    public string skinColor;
    public string outfit;

    [Header("Special Features")]
    public string specialMark;

    [Header("Behavior")]
    public string behavior;

    [Header("Profile Image (Optional)")]
    [Tooltip("Optional profile picture for the suspect. Leave empty if no image available.")]
    public Sprite profileImage;
}

