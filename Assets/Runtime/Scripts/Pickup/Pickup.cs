using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickupAudioController))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupObject;
    [SerializeField] private float pickupRotationSpeedY = 2f;
    [SerializeField] private float pickupDestroyDelay = 2f;

    private PickupAudioController pickupAudioController;

    private void Awake()
    {
        pickupAudioController = GetComponent<PickupAudioController>();
    }

    private void Update()
    {
        RotatePickup();
    }

    private void RotatePickup()
    {
        if (pickupObject && pickupObject.activeSelf == true)
        {
            pickupObject.transform.Rotate(0, pickupRotationSpeedY * Time.deltaTime, 0);
        }
    }

    private void DestroyPickupWithDelay()
    {
        Destroy(this.gameObject, pickupDestroyDelay);
    }

    public void GetPickup()
    {
        pickupObject.SetActive(false);
        pickupAudioController.PlayPickupSound();
        DestroyPickupWithDelay();
    }
}
