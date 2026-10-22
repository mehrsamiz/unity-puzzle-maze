# Setting Up Suspect Details Screen

## What Changed
✅ Added a new **Suspect Details Panel** that shows when you click a suspect
✅ Shows all suspect information (name, height, hair, outfit, special mark, behavior, image)
✅ Added "Select This Suspect" button to confirm selection
✅ Added "Back" button to return to suspect list

## New Game Flow
1. Start Screen
2. Witness Statements Screen
3. **Suspect Selection Screen** (list of 5 suspects)
4. **Suspect Details Screen** (shows when you click a suspect) ← NEW!
5. Result Screen

## Step-by-Step Unity Setup

### Step 1: Create Suspect Details Panel

1. In Hierarchy, right-click **Canvas**
2. Select: **UI → Panel**
3. Rename to **SuspectDetailsPanel**
4. Set Panel color (Inspector → Image → Color): Dark gray or black
5. Make sure **Active** checkbox is ❌ unchecked (inactive by default)

### Step 2: Add UI Elements to SuspectDetailsPanel

#### Add Suspect Name Text
1. Right-click **SuspectDetailsPanel** → **UI → Text - TextMeshPro**
2. Rename to **SuspectDetailsNameText**
3. Position at top center
4. Set text: "Suspect Name" (temporary, will be updated by script)
5. Make it large and bold (Font Size: 48)

#### Add Suspect Image (Optional)
1. Right-click **SuspectDetailsPanel** → **UI → Image**
2. Rename to **SuspectDetailsImage**
3. Position below name (or to the left side)
4. Set RectTransform size: Width 200, Height 200
5. Check **Preserve Aspect**
6. Set Color: White

#### Add Suspect Details Text
1. Right-click **SuspectDetailsPanel** → **UI → Text - TextMeshPro**
2. Rename to **SuspectDetailsInfoText**
3. Position below image (or to the right of image)
4. Set text: "Details will appear here"
5. Set Font Size: 24
6. Set alignment: Left or Center
7. Enable **Word Wrapping** if needed

#### Add "Select This Suspect" Button
1. Right-click **SuspectDetailsPanel** → **UI → Button - TextMeshPro**
2. Rename to **SelectThisSuspectButton**
3. Position at bottom center
4. Set button text: "SELECT THIS SUSPECT"
5. Make it prominent (larger size, different color)

#### Add "Back" Button
1. Right-click **SuspectDetailsPanel** → **UI → Button - TextMeshPro**
2. Rename to **BackToSuspectsButton**
3. Position at bottom left (or next to Select button)
4. Set button text: "BACK"

### Step 3: Wire Up References in UIController

1. Select **UIController** GameObject in Hierarchy
2. In Inspector, find **Murder Mystery UI Controller** component
3. Find **UI Panels** section:
   - **Suspect Details Panel** → Drag **SuspectDetailsPanel** from Hierarchy
4. Find **Suspect Details Screen** section:
   - **Suspect Details Name Text** → Drag **SuspectDetailsNameText**
   - **Suspect Details Info Text** → Drag **SuspectDetailsInfoText**
   - **Suspect Details Image** → Drag **SuspectDetailsImage** (optional)
   - **Select This Suspect Button** → Drag **SelectThisSuspectButton**
   - **Back To Suspects Button** → Drag **BackToSuspectsButton**

### Step 4: Test

1. Press **Play**
2. Navigate to Suspect Selection Screen
3. Click any suspect button
4. You should see the **Suspect Details Screen** with:
   - Suspect name at top
   - Profile image (if assigned)
   - All suspect details (height, hair, outfit, special mark, behavior)
   - "SELECT THIS SUSPECT" button
   - "BACK" button
5. Click "SELECT THIS SUSPECT" → Goes to Result Screen
6. Click "BACK" → Returns to Suspect Selection Screen

## Recommended Layout

```
┌─────────────────────────────────────┐
│     SuspectDetailsPanel              │
│                                     │
│      [Suspect Name]                 │
│                                     │
│   [Image]    Details:               │
│              Height: 165cm          │
│              Hair: Black, Short     │
│              Skin: Light            │
│              Outfit: Black jacket   │
│              Special: Tattoo         │
│              Behavior: Stressed     │
│                                     │
│   [BACK]    [SELECT THIS SUSPECT]  │
└─────────────────────────────────────┘
```

## Troubleshooting

### Details don't show when clicking suspect:
- Check: Is SuspectDetailsPanel assigned in UIController?
- Check: Are all text/image components assigned?
- Check: Console for errors (Window → General → Console)

### "Select This Suspect" button doesn't work:
- Check: Is SelectThisSuspectButton assigned in UIController?
- Check: Console for errors

### Details are empty or wrong:
- Check: Are suspects assigned to CaseSolver?
- Check: Do Suspect ScriptableObjects have data filled in?

### Can't go back to suspect list:
- Check: Is BackToSuspectsButton assigned in UIController?
- Check: Button onClick event (should be automatic via script)

## Quick Checklist

✅ SuspectDetailsPanel created (child of Canvas)
✅ SuspectDetailsNameText added and positioned
✅ SuspectDetailsInfoText added and positioned
✅ SuspectDetailsImage added (optional)
✅ SelectThisSuspectButton added
✅ BackToSuspectsButton added
✅ All references assigned in UIController
✅ SuspectDetailsPanel is inactive by default
✅ Test in Play mode

## What the Details Screen Shows

When you click a suspect, the details screen displays:
- **Name**: Full suspect name
- **Height**: In centimeters
- **Hair**: Color and length
- **Skin**: Skin color
- **Outfit**: What they're wearing
- **Special Mark**: Tattoo, watch, mole, etc.
- **Behavior**: Personality traits
- **Image**: Profile picture (if assigned)

This gives players all the information they need to make an informed decision before selecting the killer!

