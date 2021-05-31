using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{
    [SerializeField] private float teleportDistance;

    private bool[] clicked = new bool[4];
    private float[] currentTime = new float[4];
    private float timeBetweenClicks = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetKeyDownLogic(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetKeyDownLogic(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetKeyDownLogic(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetKeyDownLogic(3);
        }


        for (int i = 0; i < currentTime.Length; i++)
        {
            if (currentTime[i] > timeBetweenClicks)
            {
                clicked[i] = false;
                currentTime[i] = 0f;
            }
        }

        for (int i = 0; i < currentTime.Length; i++)
        {
            if (clicked[i])
            {
                currentTime[i] += Time.deltaTime;
            }
        }
    }

    private void GetKeyDownLogic(int button)    //0-A, 1-W, 2-D, 3-S
    {
        clicked[button] = !clicked[button];
        if (!clicked[button])
        {
            Vector3 pos = transform.position;
            if (button == 0)
                pos.x -= teleportDistance;
            else if (button == 1)
                pos.y += teleportDistance;
            else if (button == 2)
                pos.x += teleportDistance;
            else if (button == 3)
                pos.y -= teleportDistance;
            transform.position = pos;

            currentTime[button] = 0f;
        }
    }
}
