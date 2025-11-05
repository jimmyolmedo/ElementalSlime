using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosReference;

    void Start()
    {
        playerPosReference.position = player.transform.position;
    }

    void Update()
    {
        if (playerPosReference.position.x > player.transform.position.x)
        {
            transform.position += Vector3.right * 2 * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * 4 * Time.deltaTime;
        }
    }
}
