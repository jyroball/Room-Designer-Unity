using UnityEngine;
using UnityEngine.InputSystem;


public class MoveObjects : MonoBehaviour
{
    public float moveSpeed = 1f;
    public InputActionProperty moveInput; // Reference to Vector2 input from right joystick
    public InputActionProperty triggerInput; // Reference to trigger (float 0 to 1)
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;

    private bool isSelected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (triggerInput.action.ReadValue<float>() > 0.9f && hit.transform == transform)
            {
                isSelected = true;
            }
            else if (triggerInput.action.ReadValue<float>() < 0.1f)
            {
                isSelected = false;
            }
        }

        if (isSelected)
        {
            Vector2 move = moveInput.action.ReadValue<Vector2>();
            Vector3 right = Camera.main.transform.right;
            Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

            Vector3 direction = (forward * move.y + right * move.x).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
