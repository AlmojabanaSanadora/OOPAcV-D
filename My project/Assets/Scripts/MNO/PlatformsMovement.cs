using UnityEngine;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float distance = 5f; 
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private bool startMovingLeft = true; 

    private Vector3 startPosition;
    private Vector3 leftBoundary;
    private Vector3 rightBoundary;
    private bool movingLeft;

    void Start()
    {
        startPosition = transform.position;
        leftBoundary = startPosition - direction.normalized * distance;
        rightBoundary = startPosition + direction.normalized * distance;
        movingLeft = startMovingLeft; 
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        if (movingLeft)
        {
            transform.position -= direction.normalized * movement;
            if (Vector3.Distance(transform.position, leftBoundary) <= 0.1f)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.position += direction.normalized * movement;
            if (Vector3.Distance(transform.position, rightBoundary) <= 0.1f)
            {
                movingLeft = true;
            }
        }
    }
}
