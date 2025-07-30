
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickMechanics : MonoBehaviour
{
    [SerializeField] protected LayerMask layerBall;
    protected List<GameObject> balls = new();
    [SerializeField] private Transform playerTf;

    private void Start()
    {
        UIManager.instance.OnKick += Kick;
        UIManager.instance.OnKickAuto += AutoKick;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerBall) != 0)
        {
            balls.Add(other.gameObject);
            UIManager.instance.HandleBtnKick(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerBall) != 0)
        {
            balls.Remove(other.gameObject);
            if (balls.Count == 0)
                UIManager.instance.HandleBtnKick(false);
        }

    }

    private void Kick()
    {
        float distanceMin = float.MaxValue;
        GameObject ballKick = null;
        foreach (GameObject ball in balls)
        {
            float distance = Vector3.Distance(ball.transform.position, transform.position);
            if (distanceMin > distance)
            {
                distanceMin = distance;
                ballKick = ball;
            }
        }
        KickBall(ballKick);

    }

    private void AutoKick()
    {
        float distanceMax = float.MinValue;
        GameObject ballKick = null;
        foreach (Ball ball in GameManager.instance.Balls)
        {
            if (ball.IsGoal)
                continue;
            float distance = Vector3.Distance(ball.transform.position, transform.position);
            if (distanceMax < distance)
            {
                distanceMax = distance;
                ballKick = ball.gameObject;
            }
        }
        KickBall(ballKick);
    }

    private void KickBall(GameObject ballKick)
    {
        GameObject goal = FindGoal(ballKick.transform.position);
        float goalWidth = GameManager.instance.GoalWidth;
        Vector3 positionGoal = new Vector3(goal.transform.position.x, ballKick.transform.position.y, goal.transform.position.z + Random.Range(-goalWidth / 2, goalWidth / 2));
        ballKick.GetComponent<Ball>().Kick(positionGoal);
        CameraManager.instance.CameraFollow.SetTarget(ballKick.transform);

    }


    private GameObject FindGoal(Vector3 positionBall)
    {
        float distanceMin = float.MaxValue;
        GameObject goal = null;
        foreach (GameObject obj in GameManager.instance.Goals)
        {
            float distance = Vector3.Distance(positionBall, obj.transform.position);
            if (distanceMin > distance)
            {
                distanceMin = distance;
                goal = obj;
            }
        }
        return goal;
    }
}
