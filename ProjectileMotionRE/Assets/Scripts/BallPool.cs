using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [Header("Balls and Additional Balls")]
    [SerializeField] [Range(1,16)] int balls = 1;
    [SerializeField] [Range(1,8)] int addtionalBalls = 5;
    [SerializeField] GameObject ballPrefab;

    [Header("Lists")]
    [SerializeField] List<GameObject> myBalls;
    [SerializeField] List<GameObject> activeBalls;
 
    // Start is called before the first frame update
    void Awake()
    {
        activeBalls = new List<GameObject>();
        CreateBalls();
    }
    public void EnableBall(Vector3 enablePos)
    {       
        for (int i = 0; i < myBalls.Count; i++)
        {
            if (!myBalls[i].gameObject.activeInHierarchy)
            {
                myBalls[i].transform.position = enablePos;
                myBalls[i].SetActive(true);
                activeBalls.Add(myBalls[i]);
                myBalls.Remove(myBalls[i]);              
                
                return;
            }
        }        
    }   
    public void CheckAllBallsActive()
    {   
        if(activeBalls.Count == balls && addtionalBalls != 0)
        {
            AddAdditionalBall();
            balls++;
            addtionalBalls--;
            return;
        }
    }
    private void AddAdditionalBall()
    {
        GameObject spawnBall2 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        spawnBall2.transform.SetParent(transform);
        spawnBall2.gameObject.SetActive(false);
        myBalls.Add(spawnBall2);
    }
    private void CreateBalls()
    {
        myBalls = new List<GameObject>();

        for (int i = 0; i < balls; i++)
        {
            GameObject spawnBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            spawnBall.transform.SetParent(transform);
            myBalls.Add(spawnBall);
        }
        HideBalls();
    }
    private void HideBalls()
    {
        foreach (GameObject balls in myBalls)
        {
            balls.gameObject.SetActive(false);
        }
    }
    public void BackToPool(GameObject ball)
    {
        myBalls.Add(ball);
        activeBalls.Remove(ball);
    }
}
