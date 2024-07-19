using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class shootLaser : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private Transform laserSpawnPoint;

    private GameObject laserObj;
    private void Update()
    {
        HandleAttack();
    }
    private void HandleAttack() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            laserObj = Instantiate(laser, laserSpawnPoint.position, laserSpawnPoint.rotation);
        }
    }
   
    }

