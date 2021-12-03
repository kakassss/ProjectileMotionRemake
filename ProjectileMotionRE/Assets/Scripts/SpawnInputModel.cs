using UnityEngine;
using System;

[Serializable]
public class SpawnInputModel 
{
    public BallPool ballPool;
    public LayerMask ground;


    [HideInInspector] public Ray ray;
    [HideInInspector] public RaycastHit hit;
    [HideInInspector] public bool isGround;
    [HideInInspector] public bool canSpawn = true;
}
