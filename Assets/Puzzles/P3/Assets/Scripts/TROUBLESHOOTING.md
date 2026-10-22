# Troubleshooting: Blue Screen Issue

## Problem: Only seeing a blue screen when running the game

The blue screen is Unity's default camera background. This means your UI isn't showing up. Here's how to fix it:

## Quick Fix Checklist

### 1. Check if Canvas exists
- Look in the **Hierarchy** window
- Do you see a **Canvas** GameObject?
- If NO → Create one: Right-click Hierarchy → **UI → Canvas**

### 2. Check if Panels exist
- Under Canvas, do you see: StartPanel, WitnessPanel, SuspectPanel, ResultPanel?
- If NO → Create them: Right-click Canvas → **UI → Panel** (repeat 4 times)
- Rename each panel appropriately

### 3. Check Panel Visibility
- Select **StartPanel** in Hierarchy
- In Inspector, check the **Active** checkbox (should be ✅ checked)
- Other panels should be ❌ unchecked

### 4. Check Panel Colors
- Select **StartPanel**
- In Inspector, find **Image** component
- Click the **Color** field
- Change to a visible color (like dark gray or black)
- The default might be white on white, making it invisible

### 5. Check if UIController is set up
- In Hierarchy, find **UIController** GameObject
- Select it
- In Inspector, check if **Start Panel** field has StartPanel assigned
- If it says "None (GameObject)", drag StartPanel from Hierarchy into that field

### 6. Check Console for Errors
- Open **Window → General → Console**
- Look for red error messages
- Common errors:
  - "StartPanel is not assigned!" → Assign panels in UIController
  - "NullReferenceException" → Missing references

## Step-by-Step Fix

### Option A: Quick Manual Fix

1. **Create Canvas** (if missing):
   ```
   Right-click Hierarchy → UI → Canvas
   ```

2. **Create StartPanel** (if missing):
   ```
   Right-click Canvas → UI → Panel
   Rename to "StartPanel"
   ```

3. **Make StartPanel visible**:
   - Select StartPanel
   - Inspector → Image → Color → Set to dark gray (R:50, G:50, B:50)
   - Inspector → Active checkbox = ✅

4. **Add a test button**:
   ```
   Right-click StartPanel → UI → Button - TextMeshPro
   ```
   - If TextMeshPro import dialog appears, click "Import TMP Essentials"
   - Position button in center
   - Change button text to "START GAME"

5. **Wire up UIController**:
   - Select UIController GameObject
   - Inspector → Start Panel → Drag StartPanel here
   - Inspector → Start Button → Drag the button here

6. **Press Play** - You should now see the panel and button!

### Option B: Use UIHelper Script

1. Create empty GameObject: Right-click Hierarchy → **Create Empty**
2. Name it "UIHelper"
3. Add Component: `UIHelper`
4. In Inspector, right-click the component → **Create Basic UI**
5. This will create the basic panel structure
6. Then manually add buttons and text as needed

## Common Issues

### Issue: "TextMeshPro not found"
**Solution**: When creating TextMeshPro elements, Unity will ask to import. Click "Import TMP Essentials".

### Issue: Panels are white/transparent
**Solution**: 
- Select panel → Inspector → Image component
- Change Color to something visible (dark gray: R:50, G:50, B:50, A:255)

### Issue: Buttons don't work
**Solution**:
- Make sure UIController has all button references assigned
- Check Console for errors
- Verify buttons are children of active panels

### Issue: Nothing shows even with Canvas
**Solution**:
- Check Canvas → Canvas component → Render Mode = "Screen Space - Overlay"
- Check Canvas → Canvas Scaler → UI Scale Mode = "Scale With Screen Size"
- Make sure Camera exists in scene (Unity should create one automatically)

## Minimum Working Setup

To get something visible quickly:

1. **Canvas** (with CanvasScaler)
2. **StartPanel** (active, dark color)
3. **One Button** (child of StartPanel, with TextMeshPro text)
4. **UIController** (with StartPanel and StartButton assigned)

Once this works, add the other panels and buttons one by one.

## Still Not Working?

1. **Check Console** (Window → General → Console) for specific errors
2. **Check Hierarchy** - Make sure all GameObjects exist
3. **Check Inspector** - Make sure all references are assigned
4. **Try creating a simple test**: Just a Canvas with a Panel and Button, no scripts

If you see specific error messages in the Console, those will tell you exactly what's missing!

