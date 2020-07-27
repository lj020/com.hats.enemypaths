using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEditor;

using UnityEngine;

namespace com.hats.enemyPaths.editor
{
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

                for (var index = 0; index < enemyPath.WayPoints.Count; index++)
                {
                    if (enemyPath.FreeMove)
                    {
                        float y = enemyPath.WayPoints[index].y;
                        Vector3 newWayPoint = Handles.FreeMoveHandle(enemyPath.WayPoints[index], Quaternion.identity, 1, Vector3.one, Handles.SphereHandleCap);

                        if (enemyPath.FixYAxis)
                        {
                            newWayPoint.y = y;
                        }
                        enemyPath.WayPoints[index] = newWayPoint;
                    }
                    else
                    {
                        float y = enemyPath.WayPoints[index].y;
                        Vector3 newWayPoint = Handles.PositionHandle(enemyPath.WayPoints[index], Quaternion.identity);

                        if (enemyPath.FixYAxis)
                        {
                            newWayPoint.y = y;
                        }
                        enemyPath.WayPoints[index] = newWayPoint;
                    }
                }
            }
        }
    }
}
