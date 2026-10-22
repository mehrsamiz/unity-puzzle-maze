# Murder Mystery 2D - Setup Instructions

## Overview
This is a complete 2D Unity game where players read witness statements and identify the killer from 5 suspects.

## Scripts Created

1. **SuspectData.cs** - ScriptableObject for suspect information
2. **WitnessData.cs** - ScriptableObject for witness information
3. **CaseSolver.cs** - Calculates scores based on witness statements
4. **MurderMysteryUIController.cs** - Manages all UI screens
5. **GameManager.cs** - Coordinates game flow and logic

## Step-by-Step Setup

### Step 1: Create ScriptableObject Assets

#### Create Suspects (5 total):

1. Right-click in Project window → Create → Murder Mystery → Suspect Data
2. Name each one: "Suspect1_Sara", "Suspect2_Arash", etc.

**Suspect 1 - Sara Nikpour:**
- Name: Sara Nikpour
- Height: 165
- Hair Color: Black
- Hair Length: Short
- Skin Color: Light
- Outfit: Black leather jacket
- Special Mark: Small tattoo on right wrist
- Behavior: Stressed, talks fast

**Suspect 2 - Arash Kamali:**
- Name: Arash Kamali
- Height: 180
- Hair Color: Brown
- Hair Length: Medium
- Skin Color: Wheatish
- Outfit: Gray hoodie
- Special Mark: Big watch on left wrist
- Behavior: Calm, strong memory

**Suspect 3 - Parisa Rahimi:**
- Name: Parisa Rahimi
- Height: 170
- Hair Color: Blond
- Hair Length: Long
- Skin Color: Light
- Outfit: Dark green coat
- Special Mark: Dark mole on neck
- Behavior: Very anxious, avoids eye contact

**Suspect 4 - Nima Moradi:**
- Name: Nima Moradi
- Height: 175
- Hair Color: Black
- Hair Length: Short
- Skin Color: Dark
- Outfit: Blue shirt
- Special Mark: Big tattoo on right arm
- Behavior: Talks a lot, exaggerates

**Suspect 5 - Mahsa Sharifi:**
- Name: Mahsa Sharifi
- Height: 160
- Hair Color: Red
- Hair Length: Medium
- Skin Color: Light
- Outfit: Jeans
- Special Mark: (leave empty or "None")
- Behavior: Very logical, quiet

#### Create Witnesses (3 total):

1. Right-click in Project window → Create → Murder Mystery → Witness Data
2. Name each one: "Witness1", "Witness2", "Witness3"

**Witness 1:**
- Age: 27
- Statement: "I saw someone with height between 165 and 175. They were wearing a dark outfit. I noticed a tattoo on their hand."
- Min Height: 165
- Max Height: 175
- Outfit Color: dark
- Special Mark Mentioned: tattoo

**Witness 2:**
- Age: 65
- Statement: "Maybe I saw a big watch on the left hand. Maybe there was a mole on the neck. I think the outfit was blue."
- Min Height: 0
- Max Height: 0
- Outfit Color: blue
- Special Mark Mentioned: watch or mole

**Witness 3:**
- Age: 40
- Statement: "The person was around 170cm tall. They had dark short hair. I saw something special on the hand but I'm not sure what it was."
- Min Height: 165
- Max Height: 175
- Outfit Color: (leave empty)
- Special Mark Mentioned: tattoo

### Step 2: Setup Scene

1. Open `Assets/Scenes/SampleScene.unity`
2. Delete any existing GameObjects (or use a clean scene)

### Step 3: Create UI Canvas

1. Right-click in Hierarchy → UI → Canvas
2. Set Canvas Scaler:
   - UI Scale Mode: Scale With Screen Size
   - Reference Resolution: 1920 x 1080

### Step 4: Create UI Panels

Create 4 child panels under Canvas:

1. **StartPanel**
   - Add Image component (set color to dark background)
   - Add child GameObject with TextMeshPro - Text (UI) - Title: "MURDER MYSTERY"
   - Add child Button - Text: "START GAME"

2. **WitnessPanel**
   - Add Image component (set color to dark background)
   - Add 3 child TextMeshPro components for witness statements
   - Add child Button - Text: "CONTINUE"

3. **SuspectPanel**
   - Add Image component (set color to dark background)
   - Add TextMeshPro - Title: "SELECT THE KILLER"
   - Add 5 child Buttons (each with TextMeshPro child for suspect name)

4. **ResultPanel**
   - Add Image component (set color to dark background)
   - Add TextMeshPro - Title (for "CORRECT!" or "WRONG!")
   - Add TextMeshPro - Explanation (for detailed result)
   - Add Button - Text: "PLAY AGAIN"

### Step 5: Create GameObjects and Attach Scripts

1. **Create GameManager GameObject:**
   - Right-click in Hierarchy → Create Empty
   - Name: "GameManager"
   - Add Component: `GameManager`

2. **Create CaseSolver GameObject:**
   - Right-click in Hierarchy → Create Empty
   - Name: "CaseSolver"
   - Add Component: `CaseSolver`
   - In Inspector, drag all 5 Suspect ScriptableObjects to "All Suspects" list
   - Drag all 3 Witness ScriptableObjects to "All Witnesses" list

3. **Create UIController GameObject:**
   - Right-click in Hierarchy → Create Empty
   - Name: "UIController"
   - Add Component: `MurderMysteryUIController`

### Step 6: Wire Up References

**On GameManager:**
- Drag CaseSolver GameObject to "Case Solver" field
- Drag UIController GameObject to "UI Controller" field

**On UIController:**
- Drag GameManager GameObject to "Game Manager Reference" field
- Drag all 4 panels to their respective fields
- Drag all buttons to their respective fields
- Drag all TextMeshPro components to their respective fields

**On CaseSolver:**
- Already set up in Step 5

### Step 7: Initial Panel State

In the Inspector for each panel:
- StartPanel: Active = true
- WitnessPanel: Active = false
- SuspectPanel: Active = false
- ResultPanel: Active = false

## How It Works

1. **Scoring System:**
   - Each witness statement is evaluated against each suspect
   - Matching clues increase score, mismatches decrease score
   - Special marks (tattoo, watch, mole) have 3x weight
   - Reliability weights: High=3, Medium=2, Low=1

2. **The Correct Answer:**
   - Sara Nikpour should have the highest score
   - She matches: height 165 (within 165-175), dark outfit (black leather), tattoo on hand

3. **Game Flow:**
   - Start Screen → Witness Statements → Suspect Selection → Result Screen

## Testing

1. Press Play
2. Click "START GAME"
3. Read witness statements
4. Click "CONTINUE"
5. Select a suspect
6. View result

## Notes

- All logic is deterministic - same inputs always produce same results
- No external assets needed - UI uses only Unity's built-in components
- Code is beginner-friendly with clear comments
- All data is stored in ScriptableObjects for easy editing

