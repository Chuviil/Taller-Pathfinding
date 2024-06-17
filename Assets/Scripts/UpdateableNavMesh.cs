using Unity.AI.Navigation;
using UnityEngine;

[DefaultExecutionOrder(-201)]
[RequireComponent(typeof(NavMeshSurface))]
public class UpdateableNavMesh : MonoBehaviour
{
    private static bool _sNeedsNavMeshUpdate;
    private NavMeshSurface _mSurface;
    
    public static void RequestNavMeshUpdate()
    {
        _sNeedsNavMeshUpdate = true;
    }

    private void Start()
    {
        _mSurface = GetComponent<NavMeshSurface>();
        _mSurface.BuildNavMesh();
    }

    private void Update()
    {
        if (_sNeedsNavMeshUpdate)
        {
            _mSurface.UpdateNavMesh(_mSurface.navMeshData);
            _sNeedsNavMeshUpdate = false;
        }
    }
}
