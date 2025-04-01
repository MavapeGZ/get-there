using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform followTarget;
    private float distanceTargetX = 10f;
    private float camSpeed = 15f;
    public bool smoothedActivated = false;
    private Vector3 newPos;

    void Update()
    {
        newPos = this.transform.position;
        newPos.x = followTarget.transform.position.x - distanceTargetX;
        newPos.z = followTarget.transform.position.z;

        if (smoothedActivated)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, newPos, camSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.position = newPos;
        }
    }
}
