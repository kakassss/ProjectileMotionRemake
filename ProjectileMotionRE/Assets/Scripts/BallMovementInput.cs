using UnityEngine;

public class BallMovementInput : MonoBehaviour
{
    [SerializeField] MovementInputModel movementInputModel = new MovementInputModel();
    public Ball InputMovement(Ball ball)
    {
        movementInputModel.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        movementInputModel.isGround = Physics.Raycast(movementInputModel.ray, out movementInputModel.hit, Mathf.Infinity, movementInputModel.ground);

        if (Input.GetMouseButtonDown(0) && movementInputModel.isGround && !ball.dontmove)
        {
            ball.endPos = movementInputModel.hit.point;
            ball.isMoving = true;
        }
        return ball;
    }
}

