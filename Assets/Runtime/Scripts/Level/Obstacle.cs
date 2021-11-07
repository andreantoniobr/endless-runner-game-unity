using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private DecorationSpawner[] decorationSpawners;

    private List<ObstacleDecoration> obstacleDecorations = new List<ObstacleDecoration>();

    public void SpawnDecorations()
    {
        foreach (var decorationSpawner in decorationSpawners)
        {
            decorationSpawner.SpawnDecorations();
            ObstacleDecoration obstacleDecoration = decorationSpawner.CurrentDecoration.GetComponent<ObstacleDecoration>();
            if (obstacleDecoration != null)
            {
                obstacleDecorations.Add(obstacleDecoration);
            }
        }
    }

    public void PlayCollisionFeedback(Collider collider)
    {
        ObstacleDecoration decorationHit = FindDecorationForCollider(collider);
        if (decorationHit != null)
        {
            decorationHit.PlayCollisionFeedback();
        }
    }

    private ObstacleDecoration FindDecorationForCollider(Collider collider)
    {
        float minDistX = Mathf.Infinity;
        ObstacleDecoration minDistDecoration = null;
        foreach (ObstacleDecoration decoration in obstacleDecorations)
        {
            float decorationPosX = decoration.transform.position.x;
            float colliderPosX = collider.bounds.center.x;
            float distX = Mathf.Abs(decorationPosX - colliderPosX);
            if (distX < minDistX)
            {
                minDistX = distX;
                minDistDecoration = decoration;
            }
        }
        return minDistDecoration;
    }
}
