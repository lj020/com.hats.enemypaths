using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEditor;

using UnityEngine;

[CustomEditor(typeof(EnemyPath))]
[CanEditMultipleObjects]
public class DrawEnemyPath : Editor
{
    private EnemyPath enemyPath;

    private void OnSceneGUI()
    {
        enemyPath = target as EnemyPath;

        if (enemyPath == null || enemyPath.WayPoints == null || enemyPath.WayPoints.Count <= 1)
        {
            return;
        }

        using (new Handles.DrawingScope(Matrix4x4.Translate(enemyPath.transform.position)))
        {
            Handles.DrawPolyLine(enemyPath.WayPoints.ToArray());

            for (var index = 0; index < enemyPath.WayPoints.Count; index++)
            {
                enemyPath.WayPoints[index] = Handles.PositionHandle(enemyPath.WayPoints[index], Quaternion.identity);
            }
        }
    }
}
