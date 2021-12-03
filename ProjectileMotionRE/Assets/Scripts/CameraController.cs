using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Rotation")]
    [SerializeField] [Range(1,250)] float mouseSens = 65f;
    float mouseX;
    float mouseY;
    float xRotation;
    float yRotation;

    [Header("Camera Movement")]
    [SerializeField] float speed;
    [SerializeField] CharacterController controller;
    float horizontal;
    float vertical;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        GetRotationInput();
        Movement();
    }
    private void GetRotationInput()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            CameraRotation();
        }
    }
    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        direction = transform.TransformDirection(direction);

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    private void CameraRotation()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX; 

        transform.eulerAngles = new Vector3(xRotation, yRotation, transform.rotation.z);
    }
}
