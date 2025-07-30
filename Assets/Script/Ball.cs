using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float durationMoveTo;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float minSpeed = 1;
    private Vector3 positionTarget;
    private Vector3 direction;
    [SerializeField] private float speedRotation;
    private bool isGoal;

    public bool IsGoal => isGoal;

    public void Kick(Vector3 positionTarget)
    {
        this.positionTarget = positionTarget;
        direction = (positionTarget - transform.position).normalized;
        isGoal = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
        StartCoroutine(MoveTo());
    }

    private IEnumerator MoveTo()
    {
        float distanceLeft = float.MaxValue;
        float totalDistance = Vector3.Distance(transform.position, positionTarget);

        while (distanceLeft > 0.1)
        {
            distanceLeft = Vector3.Distance(transform.position, positionTarget);
            float t = distanceLeft / totalDistance;
            float speed = Mathf.Lerp(minSpeed, this.speed, t);
            transform.position += speed * direction * Time.deltaTime;

            float angle = distanceLeft * Time.deltaTime * speedRotation;
            Vector3 axis = Vector3.Cross(direction, Vector3.down).normalized;
            transform.rotation *= Quaternion.AngleAxis(angle, axis);
            yield return null;
        }
        transform.position = positionTarget;
        EffectManager.instance.OnEffectConfettiExplosion(transform.position);
        StartCoroutine(GameManager.instance.ResetCameraTarget());
    }
}
