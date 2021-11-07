using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerCollidersController : MonoBehaviour
{
    [SerializeField] private GameObject regularCollider;
    [SerializeField] private GameObject rollCollider;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        UpdateCollider(rollCollider, false);
        UpdateCollider(regularCollider, false);
    }

    private void Update()
    {
        bool isRolling = playerController.IsRolling;
        UpdateCollider(rollCollider, isRolling);
        UpdateCollider(regularCollider, !isRolling);
    }

    private void UpdateCollider(GameObject collider, bool newState)
    {
        if (collider && collider.activeSelf != newState)
        {
            collider.SetActive(newState);
        }
    }    
}
