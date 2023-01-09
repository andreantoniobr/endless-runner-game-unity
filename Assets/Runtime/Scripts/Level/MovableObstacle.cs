using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacle : Obstacle
{
    [SerializeField] private float horizontalSpeed = 1f;
    [SerializeField] private float laneSizeX = 2f;
    
    private Vector3 initialPosition;
    private float targetPositionX;
    private float deltaPosition = 0.1f;
    private float LeftLaneX => initialPosition.x - laneSizeX;
    private float RightLaneX => initialPosition.x + laneSizeX;
    

    private void Awake()
    {
        targetPositionX = LeftLaneX;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        UpdateTargetPosition(position);
        UpdatePosition(position);
    }

    private void UpdatePosition(Vector3 position)
    {
        position.x = GetHorizontalPosition();
        transform.position = position;
    }

    private void UpdateTargetPosition(Vector3 position)
    {
        if (position.x >= RightLaneX - deltaPosition)
        {
            targetPositionX = LeftLaneX;
        }
        else if (position.x <= LeftLaneX + deltaPosition)
        {
            targetPositionX = RightLaneX;
        }
    }

    private float GetHorizontalPosition()
    {
        return Mathf.Lerp(transform.position.x, targetPositionX, Time.deltaTime * horizontalSpeed);
    }
}
