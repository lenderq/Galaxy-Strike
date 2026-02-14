using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessingFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AinLasers();
    }


    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessingFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);   
    }

    private void AinLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
