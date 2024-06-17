using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshModifier))]
public class DynamicNavMeshObject : MonoBehaviour
{
    [SerializeField] private float timeOfExistence;
    
    Rigidbody _mRigidbody;
    NavMeshModifier _mNavMeshModifier;
    bool _mWasMoving;

    void Start()
    {
        _mRigidbody = GetComponent<Rigidbody>();
        _mNavMeshModifier = GetComponent<NavMeshModifier>();
        _mNavMeshModifier.enabled = true;
        _mWasMoving = !_mRigidbody.IsSleeping();

        StartCoroutine(DelayedUpdateAndDestroy());
    }

    void Update()
    {
        bool isMoving = !_mRigidbody.IsSleeping() && _mRigidbody.velocity.sqrMagnitude > 0.1f;

        if ((_mWasMoving && !isMoving) || (!_mWasMoving && isMoving))
        {
            _mNavMeshModifier.ignoreFromBuild = isMoving;
            UpdateableNavMesh.RequestNavMeshUpdate();
        }

        _mWasMoving = isMoving;
    }

    IEnumerator DelayedUpdateAndDestroy()
    {
        yield return new WaitForSeconds(timeOfExistence);
        
        UpdateableNavMesh.RequestNavMeshUpdate();
        
        Destroy(gameObject);
    }
}