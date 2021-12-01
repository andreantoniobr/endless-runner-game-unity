using Unity.VisualScripting;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private ObstacleSpawner[] obstacleSpawners;
    [SerializeField] private DecorationSpawner decorationSpawner;
    [SerializeField] private PickupSpawner pickupSpawner;

    public Transform Start => start;
    public Transform End => end;

    public float Length => Vector3.Distance(End.position, Start.position);
    public float SqrLength => (End.position - Start.position).sqrMagnitude;

    public ObstacleSpawner[] ObstacleSpawners => obstacleSpawners;
    public DecorationSpawner DecorationSpawner => decorationSpawner;

    public void SpawnPickups(float laneDistanceX)
    {
        if (pickupSpawner)
        {
            Vector3[] skipPositions = new Vector3[obstacleSpawners.Length];
            for (int i = 0; i < skipPositions.Length; i++)
            {
                skipPositions[i] = obstacleSpawners[i].transform.position;
            }        
            pickupSpawner.SpawnPickups(laneDistanceX, skipPositions);
        }       
    }
}
