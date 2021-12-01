using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabsOptions;
    [SerializeField] private int minNumberPickups;
    [SerializeField] private int maxNumberPickups;
    [SerializeField] private float spaceBetweenPickups = 0.5f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float pickupSpawnPercent;

    public void SpawnPickups(float laneDistanceX, Vector3[] skipPositions)
    {        
        float randomPickupSpawnPercent = Random.value;
        if (pickupSpawnPercent > randomPickupSpawnPercent)
        {            
            int pickupSpawnNumber = Random.Range(minNumberPickups, maxNumberPickups + 1);           
            int laneMultiplierPosition = Random.Range(-1, 2);
            float pickupPositionX = laneDistanceX * laneMultiplierPosition;
           
            for (int i = 0; i < pickupSpawnNumber; i++)
            {
                float pickupPositionZ = (i - pickupSpawnNumber / 2) * spaceBetweenPickups;
                Vector3 currentSpawnPosition = new Vector3(pickupPositionX, 0, pickupPositionZ);
                if (!ShouldSkipPosition(currentSpawnPosition, skipPositions))
                {
                    SpawnRandomPickup(currentSpawnPosition);
                }                
            }
        }        
    }

    private void SpawnRandomPickup(Vector3 currentSpawnPosition)
    {
        GameObject prefab = pickupPrefabsOptions[Random.Range(0, pickupPrefabsOptions.Length)];
        GameObject CurrentPickup = Instantiate(prefab, transform);
        CurrentPickup.transform.localPosition = currentSpawnPosition;
        CurrentPickup.transform.rotation = Quaternion.identity;
    }

    private bool ShouldSkipPosition(Vector3 currentSpawnPosition, Vector3[] skipPositions)
    {
        foreach (Vector3 skipPosition in skipPositions)
        {
            float skipStart = skipPosition.z - spaceBetweenPickups * 0.5f;
            float skipEnd = skipPosition.z + spaceBetweenPickups * 0.5f;
            if (currentSpawnPosition.z >= skipStart && currentSpawnPosition.z <= skipEnd)
            {
                return true;
            }
        }
        return false;
    }
}
