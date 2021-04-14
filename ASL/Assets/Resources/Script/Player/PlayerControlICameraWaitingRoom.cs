using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlICameraWaitingRoom : MonoBehaviour
{
    public float MouseSpeed;
    public Transform PlayerObject;
    private float XMove;

    private string MyOwnerID;
    // Start is called before the first frame update
    void Start()
    {
        MouseSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraDirection();
    }

    private void ChangeCameraDirection()
    {
        float XDirection, YDirection;
        XDirection = Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime;
        YDirection = Input.GetAxis("Mouse Y") * MouseSpeed * Time.deltaTime;
        XMove = XMove - YDirection;
        XMove = Mathf.Clamp(XMove, -90, 90);
        this.transform.localRotation = Quaternion.Euler(XMove, 0, 0);

        PlayerObject.Rotate(Vector3.up * XDirection);
        //SendAndSetClaimPlayerRotation();
    }

    private void SendAndSetClaimPlayerRotation()
    {
        GameObject Player = this.gameObject;
        if (Player != null)
        {
            Player.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
            {
                Player.GetComponent<ASL.ASLObject>().SendAndSetWorldRotation(this.transform.rotation);
            });
        }
        else
        {
            return;
        }
    }
}
