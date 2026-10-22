# How to Run the Murder Mystery Game in Unity

## Prerequisites
- Unity Editor is installed and the project is open
- All scripts are in `Assets/Scripts/` folder

## Step 1: Create ScriptableObject Assets

### Create Suspects (5 total)

1. In the Project window, right-click in `Assets/` folder
2. Select: **Create → Murder Mystery → Suspect Data**
3. Name it: `Suspect1_Sara`
4. In Inspector, fill in these values:
   - **Suspect Name**: `Sara Nikpour`
   - **Height**: `165`
   - **Hair Color**: `Black`
   - **Hair Length**: `Short`
   - **Skin Color**: `Light`
   - **Outfit**: `Black leather jacket`
   - **Special Mark**: `Small tattoo on right wrist`
   - **Behavior**: `Stressed, talks fast`

5. Repeat for the other 4 suspects:

**Suspect2_Arash:**
- Name: `Arash Kamali`
- Height: `180`
- Hair Color: `Brown`
- Hair Length: `Medium`
- Skin Color: `Wheatish`
- Outfit: `Gray hoodie`
- Special Mark: `Big watch on left wrist`
- Behavior: `Calm, strong memory`

**Suspect3_Parisa:**
- Name: `Parisa Rahimi`
- Height: `170`
- Hair Color: `Blond`
- Hair Length: `Long`
- Skin Color: `Light`
- Outfit: `Dark green coat`
- Special Mark: `Dark mole on neck`
- Behavior: `Very anxious, avoids eye contact`

**Suspect4_Nima:**
- Name: `Nima Moradi`
- Height: `175`
- Hair Color: `Black`
- Hair Length: `Short`
- Skin Color: `Dark`
- Outfit: `Blue shirt`
- Special Mark: `Big tattoo on right arm`
- Behavior: `Talks a lot, exaggerates`

**Suspect5_Mahsa:**
- Name: `Mahsa Sharifi`
- Height: `160`
- Hair Color: `Red`
- Hair Length: `Medium`
- Skin Color: `Light`
- Outfit: `Jeans`
- Special Mark: (leave empty or `None`)
- Behavior: `Very logical, quiet`

### Create Witnesses (3 total)

1. Right-click in `Assets/` folder
2. Select: **Create → Murder Mystery → Witness Data**
3. Name it: `Witness1`
4. Fill in:
   - **Age**: `27`
   - **Statement**: `I saw someone with height between 165 and 175. They were wearing a dark outfit. I noticed a tattoo on their hand.`
   - **Min Height**: `165`
   - **Max Height**: `175`
   - **Outfit Color**: `dark`
   - **Special Mark Mentioned**: `tattoo`

5. Create **Witness2**:
   - **Age**: `65`
   - **Statement**: `Maybe I saw a big watch on the left hand. Maybe there was a mole on the neck. I think the outfit was blue.`
   - **Min Height**: `0`
   - **Max Height**: `0`
   - **Outfit Color**: `blue`
   - **Special Mark Mentioned**: `watch or mole`

6. Create **Witness3**:
   - **Age**: `40`
   - **Statement**: `The person was around 170cm tall. They had dark short hair. I saw something special on the hand but I'm not sure what it was.`
   - **Min Height**: `165`
   - **Max Height**: `175`
   - **Outfit Color**: (leave empty)
   - **Special Mark Mentioned**: `tattoo`

## Step 2: Open the Scene

1. In Project window, go to `Assets/Scenes/`
2. Double-click `SampleScene.unity` to open it

## Step 3: Create UI Canvas

1. In Hierarchy window, right-click → **UI → Canvas**
2. Select the Canvas in Hierarchy
3. In Inspector, find **Canvas Scaler** component
4. Set:
   - **UI Scale Mode**: `Scale With Screen Size`
   - **Reference Resolution**: `X: 1920, Y: 1080`

## Step 4: Create UI Panels

### Create StartPanel

1. Right-click **Canvas** in Hierarchy → **UI → Panel**
2. Rename to `StartPanel`
3. Set Panel color (Inspector → Image → Color): Dark gray or black
4. Add child: Right-click **StartPanel** → **UI → Text - TextMeshPro**
   - Rename to `TitleText`
   - Set text: `MURDER MYSTERY`
   - Center it, make it large (Font Size: 72)
5. Add child button: Right-click **StartPanel** → **UI → Button - TextMeshPro**
   - Rename to `StartButton`
   - Set button text: `START GAME`
   - Position below title

### Create WitnessPanel

1. Right-click **Canvas** → **UI → Panel**
2. Rename to `WitnessPanel`
3. Set Panel color: Dark gray or black
4. Add 3 TextMeshPro children:
   - `Witness1Text` (position top-left)
   - `Witness2Text` (position middle)
   - `Witness3Text` (position bottom-left)
   - Make them readable (Font Size: 24, set RectTransform to fill space)
5. Add Button: `ContinueFromWitnessButton`
   - Text: `CONTINUE`
   - Position at bottom

### Create SuspectPanel

1. Right-click **Canvas** → **UI → Panel**
2. Rename to `SuspectPanel`
3. Set Panel color: Dark gray or black
4. Add Title: TextMeshPro `SelectTitleText` - "SELECT THE KILLER"
5. Add 5 Buttons (each with TextMeshPro child):
   - `Suspect1Button` (with child `Suspect1NameText`)
   - `Suspect2Button` (with child `Suspect2NameText`)
   - `Suspect3Button` (with child `Suspect3NameText`)
   - `Suspect4Button` (with child `Suspect4NameText`)
   - `Suspect5Button` (with child `Suspect5NameText`)
   - Arrange vertically or in a grid

### Create ResultPanel

1. Right-click **Canvas** → **UI → Panel**
2. Rename to `ResultPanel`
3. Set Panel color: Dark gray or black
4. Add TextMeshPro: `ResultTitleText` (for "CORRECT!" or "WRONG!")
5. Add TextMeshPro: `ResultExplanationText` (for detailed explanation)
6. Add Button: `PlayAgainButton` - Text: "PLAY AGAIN"

### Set Initial Panel States

1. Select **StartPanel** → Inspector → **Active** checkbox = ✅ (checked)
2. Select **WitnessPanel** → Inspector → **Active** checkbox = ❌ (unchecked)
3. Select **SuspectPanel** → Inspector → **Active** checkbox = ❌ (unchecked)
4. Select **ResultPanel** → Inspector → **Active** checkbox = ❌ (unchecked)

## Step 5: Create GameObjects and Attach Scripts

### Create GameManager

1. Right-click in Hierarchy → **Create Empty**
2. Rename to `GameManager`
3. In Inspector, click **Add Component**
4. Search for `GameManager` and add it

### Create CaseSolver

1. Right-click in Hierarchy → **Create Empty**
2. Rename to `CaseSolver`
3. Add Component: `CaseSolver`
4. In Inspector, find **All Suspects** list:
   - Set **Size** to `5`
   - Drag each suspect ScriptableObject into slots (Suspect1_Sara, Suspect2_Arash, etc.)
5. Find **All Witnesses** list:
   - Set **Size** to `3`
   - Drag each witness ScriptableObject into slots

### Create UIController

1. Right-click in Hierarchy → **Create Empty**
2. Rename to `UIController`
3. Add Component: `MurderMysteryUIController`

## Step 6: Wire Up All References

### Wire GameManager

1. Select **GameManager** in Hierarchy
2. In Inspector, find **Case Solver** field
   - Drag **CaseSolver** GameObject from Hierarchy into this field
3. Find **UI Controller** field
   - Drag **UIController** GameObject into this field

### Wire UIController

1. Select **UIController** in Hierarchy
2. In Inspector, drag references:
   - **Start Panel**: Drag `StartPanel` from Hierarchy
   - **Witness Panel**: Drag `WitnessPanel` from Hierarchy
   - **Suspect Panel**: Drag `SuspectPanel` from Hierarchy
   - **Result Panel**: Drag `ResultPanel` from Hierarchy
   - **Start Button**: Drag `StartButton` from Hierarchy
   - **Continue From Witness Button**: Drag `ContinueFromWitnessButton` from Hierarchy
   - **Suspect Buttons**: Drag each of the 5 suspect buttons
   - **Suspect Name Texts**: Drag each of the 5 TextMeshPro components (children of buttons)
   - **Result Title Text**: Drag `ResultTitleText` from Hierarchy
   - **Result Explanation Text**: Drag `ResultExplanationText` from Hierarchy
   - **Play Again Button**: Drag `PlayAgainButton` from Hierarchy
   - **Game Manager Reference**: Drag `GameManager` from Hierarchy

## Step 7: Run the Game!

1. Click the **Play** button (▶) at the top of Unity Editor
2. The game should start on the Start Screen
3. Click **START GAME** to see witness statements
4. Click **CONTINUE** to see suspect selection
5. Click a suspect button to see the result
6. Click **PLAY AGAIN** to restart

## Troubleshooting

**If buttons don't work:**
- Make sure all button references are assigned in UIController
- Check that panels are properly set active/inactive

**If suspect names don't show:**
- Make sure suspect ScriptableObjects are assigned to CaseSolver
- Check that suspect name TextMeshPro references are assigned

**If result is wrong:**
- Check that all witness data is correct (especially height ranges and special marks)
- Verify CaseSolver has all suspects and witnesses assigned

**If game doesn't start:**
- Make sure GameManager has CaseSolver and UIController references
- Check Console window for any errors (Window → General → Console)

## Quick Test Checklist

✅ All 5 Suspect ScriptableObjects created
✅ All 3 Witness ScriptableObjects created
✅ Canvas and 4 Panels created
✅ All buttons and text elements created
✅ GameManager, CaseSolver, UIController GameObjects created
✅ All scripts attached
✅ All references wired in Inspector
✅ StartPanel is active, others are inactive
✅ Press Play and test!

