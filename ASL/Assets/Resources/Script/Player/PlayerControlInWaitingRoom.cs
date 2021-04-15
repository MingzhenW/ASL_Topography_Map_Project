using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlInWaitingRoom : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpSpeed;
    public CharacterController PlayerController;
    private Vector3 NewMove;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-5, 5), 2, Random.Range(-2, -8));
        WalkSpeed = 5;
        JumpSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
    }

    private void SendAndSetClaimPlayerLoaction()
    {
        GameObject Player = this.gameObject;
        if (Player != null)
        {
            Player.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
            {
                Player.GetComponent<ASL.ASLObject>().SendAndSetWorldPosition(this.transform.position);
            });
        }
        else
        {
            return;
        }
    }

    private void ChangePosition()
    {
        float XDirection, ZDirection;

        if (PlayerController.isGrounded)
        {
            XDirection = Input.GetAxis("Horizontal");
            ZDirection = Input.GetAxis("Vertical");
            NewMove = transform.right * XDirection + transform.forward * ZDirection;
            if (Input.GetAxis("Jump") == 1)
            {
                NewMove.y = JumpSpeed;
            }
        }
        float g = 9;
        NewMove.y = NewMove.y - g * Time.deltaTime;

        PlayerController.Move(NewMove * WalkSpeed * Time.deltaTime);
        //SendAndSetClaimPlayerLoaction();
    }
}
