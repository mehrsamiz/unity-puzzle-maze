# Adding Suspect Profile Images - Unity Setup Guide

## Overview

You can now add optional profile images (pictures) for each suspect. Images are completely optional - if you don't add them, the game will work fine without images.

## Step 1: Prepare Your Images

1. **Get or create images** for each suspect (portrait photos work best)
2. **Supported formats**: PNG, JPG, JPEG
3. **Recommended size**: 256x256 to 512x512 pixels (square images work best)
4. **Import images into Unity**:
   - Drag image files into `Assets/` folder (or create an `Assets/Images/` folder)
   - Unity will automatically import them as Sprites

## Step 2: Configure Image Import Settings

1. Select an imported image in Project window
2. In Inspector, check these settings:

   - **Texture Type**: Should be "Sprite (2D and UI)"
   - If it's not, change it and click **Apply**
   - **Pixels Per Unit**: 100 (default is fine)
   - Click **Apply** if you changed anything

3. Repeat for all suspect images

## Step 3: Assign Images to Suspect ScriptableObjects

1. Select a Suspect ScriptableObject (e.g., `Suspect1_Sara`)
2. In Inspector, find **Profile Image (Optional)** field
3. **Drag the image Sprite** from Project window into this field
4. Repeat for all 5 suspects
   - You can leave some empty if you don't have images for all suspects

## Step 4: Add Image Components to UI

### For Suspect Selection Screen:

1. **Select SuspectPanel** in Hierarchy
2. For each suspect button (Suspect1Button, Suspect2Button, etc.):
   - **Select the button** in Hierarchy
   - **Add Image component**: Inspector → Add Component → Image
   - **OR** if the button already has an Image (for background), create a child GameObject:
     - Right-click the button → **UI → Image**
     - Rename it to "Suspect1Image", "Suspect2Image", etc.
   - **Position the image** above or next to the name text
   - **Set Image settings**:
     - **Image Type**: Simple
     - **Preserve Aspect**: ✅ (checked) - keeps image proportions
     - **Color**: White (or adjust as needed)

### Recommended Button Layout:

```
Suspect1Button
  ├── Suspect1Image (Image component - shows profile picture)
  └── Suspect1NameText (TextMeshPro - shows name)
```

## Step 5: Wire Up Image References in UIController

1. **Select UIController** GameObject in Hierarchy
2. In Inspector, find **Murder Mystery UI Controller** component
3. Find **Suspect Profile Images (Optional)** section
4. **Drag each Image component** from Hierarchy into the corresponding field:
   - **Suspect 1 Image** → Drag Suspect1Image
   - **Suspect 2 Image** → Drag Suspect2Image
   - **Suspect 3 Image** → Drag Suspect3Image
   - **Suspect 4 Image** → Drag Suspect4Image
   - **Suspect 5 Image** → Drag Suspect5Image

## Step 6: Add Image to Result Screen (Optional)

1. **Select ResultPanel** in Hierarchy
2. **Add Image component**: Right-click ResultPanel → **UI → Image**
   - Rename to "ResultSuspectImage"
   - Position it near the result text
   - **Set Image settings**:
     - **Image Type**: Simple
     - **Preserve Aspect**: ✅ (checked)
     - **Color**: White
3. **Wire it up**:
   - Select **UIController**
   - In Inspector, find **Result Suspect Image** field
   - Drag **ResultSuspectImage** from Hierarchy into this field

## Step 7: Test

1. **Press Play**
2. Navigate to **Suspect Selection Screen**
3. You should see profile images next to each suspect name
4. If an image is missing for a suspect, that image component will be hidden automatically
5. On **Result Screen**, you should see the killer's profile image

## Troubleshooting

### Images don't show up:

- **Check**: Are images assigned to Suspect ScriptableObjects?
- **Check**: Are Image components assigned in UIController?
- **Check**: Are Image components enabled? (Inspector → Image → Enabled checkbox)
- **Check**: Are images positioned correctly? (might be behind other UI elements)

### Images are stretched/distorted:

- Select Image component → Inspector
- Check **Preserve Aspect** checkbox
- Adjust **RectTransform** size to be square (same width and height)

### Images are too small/large:

- Select Image GameObject
- In Inspector → **RectTransform**
- Adjust **Width** and **Height** values
- Recommended: 150-200 pixels for suspect selection screen

### Some images show, others don't:

- This is normal! Images are optional
- If a suspect doesn't have a profile image assigned, that Image component will be automatically hidden
- Make sure you assigned images to the Suspect ScriptableObjects

## Quick Setup Checklist

✅ Images imported into Unity (as Sprites)
✅ Image import settings: Texture Type = "Sprite (2D and UI)"
✅ Images assigned to Suspect ScriptableObjects (Profile Image field)
✅ Image components added to suspect buttons (or as children)
✅ Image components wired up in UIController
✅ (Optional) Result image added and wired up
✅ Test in Play mode

## Example Layout

**Suspect Selection Screen:**

```
┌─────────────────────────────┐
│   Suspect Selection          │
├─────────────────────────────┤
│  [Image]  Sara Nikpour      │ ← Button 1
│  [Image]  Arash Kamali      │ ← Button 2
│  [Image]  Parisa Rahimi     │ ← Button 3
│  [Image]  Nima Moradi       │ ← Button 4
│  [Image]  Mahsa Sharifi     │ ← Button 5
└─────────────────────────────┘
```

**Result Screen:**

```
┌─────────────────────────────┐
│      CORRECT!               │
│   [Killer Image]            │
│   Explanation text...       │
└─────────────────────────────┘
```

## Notes

- **Images are completely optional** - the game works fine without them
- If you don't assign an image to a suspect, that Image component will be automatically hidden
- You can use placeholder images, colored squares, or actual photos
- Images should be square for best results (or use Preserve Aspect)
- The system automatically handles missing images gracefully
