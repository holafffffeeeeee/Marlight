using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector2 screenBounds;  // Defines the screen bounds where the player can move before the camera teleports
    public Vector2 cameraShift;  // How much the camera should shift when teleporting

    private Vector3 lastCameraPosition;

    void Start()
    {
        // Set the initial camera position
        lastCameraPosition = transform.position;
    }

    void Update()
    {
        Vector3 playerPos = player.position;
        Vector3 cameraPos = transform.position;

        // Check if the player has moved outside the screen bounds
        if (playerPos.x > cameraPos.x + screenBounds.x)
        {
            // Move camera to the right
            cameraPos.x += cameraShift.x;
        }
        else if (playerPos.x < cameraPos.x - screenBounds.x)
        {
            // Move camera to the left
            cameraPos.x -= cameraShift.x;
        }

        if (playerPos.y > cameraPos.y + screenBounds.y)
        {
            // Move camera up
            cameraPos.y += cameraShift.y;
        }
        else if (playerPos.y < cameraPos.y - screenBounds.y)
        {
            // Move camera down
            cameraPos.y -= cameraShift.y;
        }

        // Teleport the camera if it needs to move
        if (cameraPos != lastCameraPosition)
        {
            transform.position = cameraPos;
            lastCameraPosition = cameraPos;
        }
    }
}
