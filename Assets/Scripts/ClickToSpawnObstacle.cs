using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform obstacleParent;
    
    private RaycastHit _mHitInfo;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out _mHitInfo))
            {
                Vector3 spawnPostion = new Vector3(_mHitInfo.point.x, 4f, _mHitInfo.point.z);
                Instantiate(obstaclePrefab, spawnPostion, Quaternion.identity, obstacleParent);
            }
        }
    }
}