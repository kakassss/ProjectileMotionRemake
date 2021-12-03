using UnityEngine;
using System;

[Serializable]
public class MovementInputModel
{
    public LayerMask ground;
    public BallPool ballPool;

    [HideInInspector] public Ray ray;
    [HideInInspector] public RaycastHit hit;
    [HideInInspector] public bool isGround;

}
