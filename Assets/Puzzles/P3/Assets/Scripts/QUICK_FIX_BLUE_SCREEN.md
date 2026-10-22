# Quick Fix for Blue Screen

## The Problem
You see only a blue screen = Unity's camera background. Your UI isn't showing.

## 5-Minute Fix

### Step 1: Create Canvas (if missing)
1. In **Hierarchy** window, right-click
2. Select: **UI → Canvas**
3. A Canvas should appear in Hierarchy

### Step 2: Create StartPanel
1. Right-click **Canvas** in Hierarchy
2. Select: **UI → Panel**
3. Rename it to **StartPanel**
4. Select **StartPanel**
5. In Inspector:
   - Find **Image** component
   - Click **Color** field
   - Set to: **R: 50, G: 50, B: 50, A: 255** (dark gray)
   - Make sure **Active** checkbox is ✅ checked

### Step 3: Add a Button
1. Right-click **StartPanel** in Hierarchy
2. Select: **UI → Button - TextMeshPro**
3. If a dialog appears asking to import TextMeshPro, click **"Import TMP Essentials"**
4. Select the button (it's a child of StartPanel)
5. In Inspector, find the **Text (TMP)** child
6. Change text to: **"START GAME"**

### Step 4: Wire Up UIController
1. In Hierarchy, find **UIController** GameObject
2. Select it
3. In Inspector, find **Murder Mystery UI Controller** component
4. Find **Start Panel** field
5. **Drag StartPanel from Hierarchy into this field**
6. Find **Start Button** field  
7. **Drag the button from Hierarchy into this field**

### Step 5: Test
1. Press **Play** button (▶)
2. You should now see a dark gray panel with a "START GAME" button!

## If Still Blue Screen

### Check These:
1. **Is Canvas active?** (Select Canvas → Inspector → Active = ✅)
2. **Is StartPanel active?** (Select StartPanel → Inspector → Active = ✅)
3. **Is StartPanel a child of Canvas?** (Should see Canvas → StartPanel in Hierarchy)
4. **Check Console**: Window → General → Console
   - Look for red errors
   - If you see "StartPanel is not assigned!" → You need to assign it in Step 4

## Visual Hierarchy Should Look Like:
```
Canvas
  ├── StartPanel (Active ✅)
  │   └── Button
  │       └── Text (TMP) - "START GAME"
  ├── WitnessPanel (Active ❌)
  ├── SuspectPanel (Active ❌)
  └── ResultPanel (Active ❌)
```

## Next Steps
Once you see the StartPanel working:
1. Create the other 3 panels (WitnessPanel, SuspectPanel, ResultPanel)
2. Add buttons and text to each
3. Assign all references in UIController
4. See HOW_TO_RUN.md for complete setup

