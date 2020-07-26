using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

namespace com.hats.enemyPaths
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField]
        private List<Vector3> wayPoints;

        public List<Vector3> WayPoints => wayPoints ?? (wayPoints = new List<Vector3>());

        [SerializeField]
        private Boolean freeMove = false;

        public bool FreeMove => freeMove;

        [SerializeField]
        private Color pathColor = Color.green;

        public Color PathColor => pathColor;

#if UNITY_EDITOR

        [SerializeField]
        private GizmoVisibility pathVisibility;

        private void OnDrawGizmos()
        {
            if (pathVisibility != GizmoVisibility.DrawAlways) { return; }

            DrawGizmos();
        }

        private void OnDrawGizmosSelected()
        {
            if (pathVisibility != GizmoVisibility.DrawSelected) { return; }

            DrawGizmos();
        }

        private void DrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.Translate(transform.position);
            Gizmos.color = pathColor;
            for (var index = 0; index < wayPoints.Count - 1; index++)
            {
                Gizmos.DrawLine(wayPoints[index], wayPoints[index + 1]);
            }
        }

#endif
    }
}
