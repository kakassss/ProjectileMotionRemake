using UnityEngine;

public class BallSpawnInput : MonoBehaviour
{
    [SerializeField] SpawnInputModel spawnInputModel = new SpawnInputModel();
    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BallSpawnCheckInput();
        }
    }
    private void BallSpawnCheckInput()
    {
        spawnInputModel.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        spawnInputModel.isGround = Physics.Raycast(spawnInputModel.ray, out spawnInputModel.hit, Mathf.Infinity, spawnInputModel.ground);

        if (spawnInputModel.canSpawn && spawnInputModel.isGround)
        {
            spawnInputModel.ballPool.EnableBall(spawnInputModel.hit.point);
            spawnInputModel.ballPool.CheckAllBallsActive();
        }
        spawnInputModel.canSpawn = !spawnInputModel.canSpawn;      
    }
}
