using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] public Ball myBall = new Ball();

    private BallMovement ballMovement;
    private BallMovementInput ballMovementInput;
    private UIManager UIManager;

    private void OnEnable()
    {
        myBall.startPos = myBall.transform.position;
    }
    private void Start()
    {
        ballMovementInput = GetComponent<BallMovementInput>();
        ballMovement = GetComponent<BallMovement>();
        UIManager = FindObjectOfType<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        ballMovementInput.InputMovement(myBall);
        ballMovement.Movement(myBall);

        PrintDestinationPos();
        CanChangeSpeed();
    } 
    private void CanChangeSpeed()
    {
        if (!myBall.dontmove)
        {
            UIManager.ballUI(myBall);
        }
    }
    private void PrintDestinationPos()
    {
        if(myBall.endPos == Vector3.zero)
        {
            return;
        }
        UIManager.DesPosBall(myBall);
    }
}
