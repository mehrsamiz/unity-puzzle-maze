# Quick Reference: Adding Suspect Images

## What Changed in Code
✅ `SuspectData.cs` - Added optional `profileImage` (Sprite) field
✅ `MurderMysteryUIController.cs` - Added image display support
✅ Images automatically show/hide based on availability

## What You Need to Do in Unity

### 1. Import Images (if you have them)
- Drag PNG/JPG files into `Assets/` folder
- Select each image → Inspector → Texture Type = "Sprite (2D and UI)" → Apply

### 2. Assign to Suspects
- Open each Suspect ScriptableObject
- Find "Profile Image (Optional)" field
- Drag image Sprite into this field
- Leave empty if no image available

### 3. Add Image Components to UI
For each suspect button:
- Select Suspect1Button (or Suspect2Button, etc.)
- Add child: Right-click → UI → Image
- Rename to "Suspect1Image"
- Set RectTransform size (e.g., 150x150)
- Check "Preserve Aspect"

### 4. Wire Up in UIController
- Select UIController GameObject
- In Inspector, find "Suspect Profile Images (Optional)"
- Drag each Image component into corresponding field

### 5. (Optional) Result Screen Image
- Select ResultPanel
- Add child: Right-click → UI → Image
- Rename to "ResultSuspectImage"
- In UIController, drag to "Result Suspect Image" field

## That's It!
Images are optional - game works fine without them. If no image is assigned, the Image component automatically hides.

