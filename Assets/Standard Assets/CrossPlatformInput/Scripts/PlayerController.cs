using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour 
{

    [Header("General")]
    [Tooltip("in ms^-1")][SerializeField] float speed = 50f;
    [Tooltip("x Screen Limit")][SerializeField] float xRange = 27f;
    [Tooltip("y Screen Limit")][SerializeField] float yRange = 16f;
    [SerializeField] float zPos = 45f;

    [SerializeField] float pitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -18f;

    [SerializeField] float yawFactor = 1.6f;

    [SerializeField] float controlRollFactor = -30f;
    [SerializeField] GameObject[] guns;

    bool disableControl = false;


    float xThrow, yThrow;


    // Update is called once per frame
    void Update()
    {
        if (!disableControl) //check if player is dead
        {
            MoveShip();
            gunHandler();
        }
    }

    private void gunHandler()
    {
        bool fireGun = CrossPlatformInputManager.GetButton("Fire1");

        triggerFire(fireGun);
    }

    private void triggerFire(bool active)
    {
        if (active)
        {
            foreach (GameObject gun in guns)
            {

                //gun.SetActive(true);
                ParticleSystem ps = gun.GetComponentInChildren<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = active;
            }
        }
        else
        {
            foreach (GameObject gun in guns)
            {
                //gun.SetActive(false);
                ParticleSystem ps = gun.GetComponentInChildren<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = active;
            }
        }
    }

    private void PlayerIsHit(bool isHit) //called by reference string
    {
        disableControl = isHit;
    }

    private void MoveShip()
    {
        float yPos = MoveUpDown();

        float xPos = MoveSideWays();

        PitchYawRoll();

        transform.localPosition = new Vector3(xPos, yPos, zPos);
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
        float clampedXPos = MoveLimit(xPos, xOffset, xRange);
        return clampedXPos;
    }

    private float MoveUpDown()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // initialize multiplatform control for y axis
        float yPos = transform.localPosition.y;
        float yOffset = Offset(yThrow, speed);
        float clampedYPos = MoveLimit(yPos, yOffset,yRange);
        return clampedYPos;
    }

    private float MoveLimit(float pos, float offset, float range)
    {
        return Mathf.Clamp((pos + offset), -range, range); // checks if the proposed movement is in range of the screen 
    }

    private float Offset(float throwValue,float speed)
    {
        float offSet = throwValue * speed * Time.deltaTime; // make the movement calculations fps dependent
        return offSet;
    }

}
