using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

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
}
