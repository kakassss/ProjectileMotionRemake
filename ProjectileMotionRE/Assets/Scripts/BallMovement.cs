using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] BallPool ballpool;

    private void Start()
    {
        ballpool = GetComponentInParent<BallPool>();
    }
    public Ball Movement(Ball ball)
    {
        if (ball.endPos == Vector3.zero)
        {
            return null;
        }

        if (ball.isMoving)
        {
            ball.dontmove = true;//dontmove'un yaptýðý, top hareket halindeyken baþka bir yere yönlenmemesini saðlamak

            ball.dist = ball.endPos - ball.startPos;
            ball.next = Vector3.MoveTowards(ball.transform.position, ball.endPos, ball.speed * Time.deltaTime);

            ball.baseY = Mathf.Lerp(ball.startPos.y, ball.endPos.y, (ball.next.y - ball.startPos.y) / ball.dist.x);
            ball.height = ball.launchHeight * (ball.next.x - ball.startPos.x) * (ball.next.x - ball.endPos.x) / (-0.25f * ball.dist.x * ball.dist.x);

            ball.movePosition = new Vector3(ball.next.x, ball.baseY + ball.height, ball.next.z);

            ball.transform.position = ball.movePosition;

            if (transform.position.x == ball.endPos.x || transform.position.z == ball.endPos.z)
            {
                ball.transform.gameObject.SetActive(false);

                ballpool.BackToPool(ball.transform.gameObject);

                ball.isMoving = false;
                ball.dontmove = false;

            }

        }

        return ball;
    }
}
