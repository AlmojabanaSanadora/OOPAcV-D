using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] private Transform resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger. Resetting position.");

            other.transform.position = resetPoint.position;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
}
