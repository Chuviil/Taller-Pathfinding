using UnityEngine;

public class DisableOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var pointsNavigation = other.gameObject.GetComponent<PointsNavigation>();
            pointsNavigation.SetNextGoal();
            Destroy(gameObject);
        }
    }
}
