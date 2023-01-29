using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform mainPlayer;
    private Vector3 playerPostionEveryFrame = Vector3.zero;

    private float deltaX = 9f;
    private float deltaY = 7f;
    private float deltaZ = 4f;

    void Update()
    {
        playerPostionEveryFrame = mainPlayer.position;
        transform.position = new Vector3(playerPostionEveryFrame.x - deltaX, playerPostionEveryFrame.y + deltaY, playerPostionEveryFrame.z + deltaZ);
    }
}
