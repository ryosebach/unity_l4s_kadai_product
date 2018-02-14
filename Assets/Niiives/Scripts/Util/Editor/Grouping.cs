using UnityEditor;
using UnityEngine;

public static class Grouping
{
    [MenuItem("Edit/Group %g")]
    private static void Execute()
    {
        var gameObjects = Selection.gameObjects;

        if (gameObjects.Length < 0) return;

        var group = new GameObject("Group");
        Undo.RegisterCreatedObjectUndo(group, "Group");
        foreach (var go in gameObjects)
        {
            Undo.SetTransformParent(go.transform, group.transform, "Group");
        }

        Selection.activeGameObject = group;
    }

    [MenuItem("Edit/Group %g", true)]
    private static bool CanExecute()
    {
        return 0 < Selection.transforms.Length;
    }
}