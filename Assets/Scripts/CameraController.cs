using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mouseInput;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Transform playerPosition;

    /// <summary>
    /// Moves the camera in orbit around the player using the mouse movement
    /// for vertical pitching & horizontal rotation.
    /// </summary>
    void Update()
    {
        mouseInput = new Vector3(-Input.mousePositionDelta.x, -Input.mousePositionDelta.y, 0).normalized;
        transform.Translate(mouseInput * cameraSpeed * Time.deltaTime);
        transform.LookAt(playerPosition, Vector3.up);
    }
}
