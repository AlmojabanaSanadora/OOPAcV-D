using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float mouseSensitivity = 200f;
    public Transform cameraTransform;
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private float xRotation = 0f;
    private bool isGrounded;

    private Vector3 objectVelocity; 
    private Transform currentObject; 
    private Vector3 lastObjectPosition; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleJump();
        UpdateObjectMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical"); 

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized * moveSpeed;
        Vector3 targetVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z); 
        rb.linearVelocity = targetVelocity; 
    }

    private void HandleJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentObject = null;
        }
    }

    private void UpdateObjectMovement()
    {
        if (isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance + 0.1f))
            {
                Transform obj = hit.collider.transform;

                if (currentObject == obj)
                {
                    objectVelocity = obj.position - lastObjectPosition;
                }
                else
                {
                    objectVelocity = Vector3.zero; 
                }

                currentObject = obj;
                lastObjectPosition = obj.position; 
            }
            else
            {
                currentObject = null;
                objectVelocity = Vector3.zero;
            }
        }
        else
        {
            currentObject = null;
            objectVelocity = Vector3.zero;
        }

        if (currentObject != null)
        {
            transform.position += objectVelocity;
        }
    }
}