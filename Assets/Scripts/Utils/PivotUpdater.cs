using UnityEditor;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public static class PivotUpdater
{
    [MenuItem("Custom/Update Sprite Pivots")]
    static void UpdatePivot()
    {
        foreach (var obj in Selection.objects)
        {
            if (obj is Texture2D)
            {
                var factory = new SpriteDataProviderFactories();
                factory.Init();
                var dataProvider = factory.GetSpriteEditorDataProviderFromObject(obj);
                dataProvider.InitSpriteEditorDataProvider();

                SetPivot(dataProvider, new Vector2(0.5f, 0.065f));
                SetPhysicsShape(dataProvider);

                dataProvider.Apply();

                // Optional: If you want to auto save your changes
                AutoSaveChanges(dataProvider);
            }
        }
    }

    static void SetPivot(ISpriteEditorDataProvider dataProvider, Vector2 pivot)
    {
        var spriteRects = dataProvider.GetSpriteRects();
        foreach (var rect in spriteRects)
        {
            rect.pivot = pivot;
            rect.alignment = SpriteAlignment.Custom;
        }
        dataProvider.SetSpriteRects(spriteRects);
    }

    static void SetPhysicsShape(ISpriteEditorDataProvider dataProvider)
    {
        var physicsOutlineDataProvider = dataProvider.GetDataProvider<ISpritePhysicsOutlineDataProvider>();
        var rects = dataProvider.GetSpriteRects();
        foreach (var rect in rects)
        {
            var outlines = physicsOutlineDataProvider.GetOutlines(rect.spriteID);
            // Do changes
            physicsOutlineDataProvider.SetOutlines(rect.spriteID, outlines);
        }
    }

    static void AutoSaveChanges(ISpriteEditorDataProvider dataProvider)
    {
        var assetImporter = dataProvider.targetObject as AssetImporter;
        assetImporter.SaveAndReimport();
    }
}
