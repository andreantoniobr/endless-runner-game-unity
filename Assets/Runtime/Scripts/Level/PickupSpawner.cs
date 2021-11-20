using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabsOptions;
    [SerializeField] private int minNumberPickups;
    [SerializeField] private int maxNumberPickups;
    [SerializeField] private float pickupDistanceZ = 2f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float pickupSpawnPercent;

    public void SpawnPickups(float laneDistanceX)
    {        
        float randomPickupSpawnPercent = Random.Range(0.0f, 1.0f);
        if (pickupSpawnPercent > randomPickupSpawnPercent)
        {            
            int pickupSpawnNumber = Random.Range(minNumberPickups, maxNumberPickups + 1);
           
            int laneMultiplierPosition = Random.Range(-1, 2);
            float pickPositionX = laneDistanceX * laneMultiplierPosition;
           
            for (int i = 0; i < pickupSpawnNumber; i++)
            {
                GameObject prefab = pickupPrefabsOptions[Random.Range(0, pickupPrefabsOptions.Length)];
                GameObject CurrentPickup = Instantiate(prefab, transform);
                float pickupPositionZ = (i - pickupSpawnNumber / 2) * pickupDistanceZ;
                CurrentPickup.transform.localPosition = new Vector3(pickPositionX, 0, pickupPositionZ);
                CurrentPickup.transform.rotation = Quaternion.identity;
            }
        }        
    }
}
