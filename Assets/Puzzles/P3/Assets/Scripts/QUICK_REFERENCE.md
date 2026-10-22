# Quick Reference - ScriptableObject Data Values

## Suspects (Create 5 ScriptableObjects)

### Suspect 1: Sara Nikpour
```
Name: Sara Nikpour
Height: 165
Hair Color: Black
Hair Length: Short
Skin Color: Light
Outfit: Black leather jacket
Special Mark: Small tattoo on right wrist
Behavior: Stressed, talks fast
```

### Suspect 2: Arash Kamali
```
Name: Arash Kamali
Height: 180
Hair Color: Brown
Hair Length: Medium
Skin Color: Wheatish
Outfit: Gray hoodie
Special Mark: Big watch on left wrist
Behavior: Calm, strong memory
```

### Suspect 3: Parisa Rahimi
```
Name: Parisa Rahimi
Height: 170
Hair Color: Blond
Hair Length: Long
Skin Color: Light
Outfit: Dark green coat
Special Mark: Dark mole on neck
Behavior: Very anxious, avoids eye contact
```

### Suspect 4: Nima Moradi
```
Name: Nima Moradi
Height: 175
Hair Color: Black
Hair Length: Short
Skin Color: Dark
Outfit: Blue shirt
Special Mark: Big tattoo on right arm
Behavior: Talks a lot, exaggerates
```

### Suspect 5: Mahsa Sharifi
```
Name: Mahsa Sharifi
Height: 160
Hair Color: Red
Hair Length: Medium
Skin Color: Light
Outfit: Jeans
Special Mark: None (or leave empty)
Behavior: Very logical, quiet
```

## Witnesses (Create 3 ScriptableObjects)

### Witness 1
```
Age: 27
Statement: I saw someone with height between 165 and 175. They were wearing a dark outfit. I noticed a tattoo on their hand.
Min Height: 165
Max Height: 175
Outfit Color: dark
Special Mark Mentioned: tattoo
```

### Witness 2
```
Age: 65
Statement: Maybe I saw a big watch on the left hand. Maybe there was a mole on the neck. I think the outfit was blue.
Min Height: 0
Max Height: 0
Outfit Color: blue
Special Mark Mentioned: watch or mole
```

### Witness 3
```
Age: 40
Statement: The person was around 170cm tall. They had dark short hair. I saw something special on the hand but I'm not sure what it was.
Min Height: 165
Max Height: 175
Outfit Color: (leave empty)
Special Mark Mentioned: tattoo
```

## Expected Result

**Sara Nikpour** should be identified as the killer because:
- Matches Witness 1 (High reliability): Height 165, dark outfit (black leather), tattoo on hand
- Matches Witness 3 (Medium reliability): Height 165, tattoo on hand
- Witness 2 (Low reliability) has conflicting information, but her low reliability means less impact

