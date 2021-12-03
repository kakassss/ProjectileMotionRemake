using UnityEngine;
using System;

[Serializable]
public class Ball
{
    public float speed = 10f;
    public float launchHeight = 2;

    public Transform transform;

    [HideInInspector] public Vector3 movePosition;

    [HideInInspector] public Vector3 next;
    [HideInInspector] public Vector3 dist;
    [HideInInspector] public float baseY;
    [HideInInspector] public float height;

    
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool dontmove = false;

    [HideInInspector] public Vector3 startPos;
    [HideInInspector] public Vector3 endPos;
}
