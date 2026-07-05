using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mouseInput;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Transform playerPosition;

    void Update()
    {
        mouseInput = new Vector3(-Input.mousePositionDelta.x, 0, 0).normalized;
        transform.Translate(mouseInput * cameraSpeed * Time.deltaTime);
        transform.LookAt(playerPosition, Vector3.up);
    }


}
