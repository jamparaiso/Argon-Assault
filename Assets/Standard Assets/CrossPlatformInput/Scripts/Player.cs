using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
  
{
    [Tooltip("in ms^-1")][SerializeField] float speed = 50f;
    [Tooltip("x Screen Limit")][SerializeField] float xRange = 27f;
    [Tooltip("y Screen Limit")][SerializeField] float yRange = 16f;

    [SerializeField] float pitchFactor = -1.5f;
    [SerializeField] float controlPitchFactor = -18f;

    [SerializeField] float yawFactor = 1.6f;

    [SerializeField] float controlRollFactor = -30f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
    }

    private void MoveShip()
    {
        float rawYpos = MoveUpDown();

        float rawXPos = MoveSideWays();

        PitchYawRoll();

        transform.localPosition = new Vector3(rawXPos, rawYpos, transform.localPosition.z);
    }
    private void PitchYawRoll()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x + yawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    private float MoveSideWays()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // initialize multiplatform control for x axis
        float xPos = transform.localPosition.x;
        float xOffset = Offset(xThrow, speed);
        float rawXPos = MoveLmit(xPos, xOffset, xRange);
        return rawXPos;
    }

    private float MoveUpDown()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yPos = transform.localPosition.y;
        float yOffset = Offset(yThrow, speed);
        float rawYpos = MoveLmit(yPos, yOffset,yRange);
        return rawYpos;
    }

    private float MoveLmit(float pos, float offset, float range)
    {
        return Mathf.Clamp((pos + offset), -range, range);
    }

    private float Offset(float throwSpeed,float speed)
    {
        float offSet = throwSpeed * speed * Time.deltaTime;
        return offSet;
    }
}
