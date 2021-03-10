using System.Collections.Generic;

using Sirenix.OdinInspector;

using UnityEngine;

namespace com.hats.enemyPaths
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField]
        private List<Vector3> wayPoints;

        public List<Vector3> WayPoints => wayPoints ?? (wayPoints = new List<Vector3>());

        public List<GameObject> movingObjects;

        [OnValueChanged(nameof(SetStartPosition))]
        public int startPosition;

        [SerializeField]
        private bool fixYAxis = false;

        public bool FixYAxis => fixYAxis;

        [Title("Visualisation")]
        [EnumToggleButtons]
        [SerializeField]
        private HandleVisualisation handleVisualisation = HandleVisualisation.Arrows;

        public HandleVisualisation HandleVisualisation => handleVisualisation;

        [SerializeField]
        private Color pathColor = Color.green;

        public Color PathColor => pathColor;

        [SerializeField]
        private GizmoVisibility pathVisibility;

        private void SetStartPosition()
        {
#if UNITY_EDITOR

            startPosition = Mathf.Clamp(startPosition, 0, wayPoints.Count - 1);

            movingObjects.ForEach(go => go.transform.localPosition = wayPoints[startPosition]);
#endif
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (pathVisibility != GizmoVisibility.Always) { return; }

            DrawGizmos();
        }

        private void OnDrawGizmosSelected()
        {
            if (pathVisibility != GizmoVisibility.Selected) { return; }

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
