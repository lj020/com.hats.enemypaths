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
            Handles.color = enemyPath.PathColor;  
            Handles.DrawPolyLine(enemyPath.WayPoints.ToArray());

            for (var index = 0; index < enemyPath.WayPoints.Count; index++)
            {

                if (enemyPath.FreeMove)
                { 
                  enemyPath.WayPoints[index] = 
                      Handles.FreeMoveHandle(enemyPath.WayPoints[index], Quaternion.identity, 1, new Vector3(1, 1, 1), Handles.SphereHandleCap);  
                }
                else
                {
                    enemyPath.WayPoints[index] = Handles.PositionHandle(enemyPath.WayPoints[index], Quaternion.identity);
                }
            }
        }
    }
}
