using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlFlashLight : MonoBehaviour
{
    public GameObject PlayerObject;
    private static GameObject MyFlashLight;
    private bool IfOn = false;
    // Start is called before the first frame update
    void Start()
    {
        ASL.ASLHelper.InstantiateASLObject("PlayerFlashLight", new Vector3(0, 60, 0), Quaternion.identity, "", "", GetLightObject);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlashLightPositionAndRotation();
        ControlFlashLight();
    }

    private void ControlFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (IfOn)
            {
                MyFlashLight.SetActive(false);
                IfOn = false;
            }
            else
            {
                MyFlashLight.SetActive(true);
                IfOn = true;
            }
        }
    }

    private void UpdateFlashLightPositionAndRotation()
    {
        MyFlashLight.transform.position = PlayerObject.transform.position;
        MyFlashLight.transform.rotation = PlayerObject.transform.rotation;

        MyFlashLight.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
        {
            MyFlashLight.GetComponent<ASL.ASLObject>().SendAndSetWorldRotation(PlayerObject.transform.rotation);
            MyFlashLight.GetComponent<ASL.ASLObject>().SendAndSetWorldPosition(PlayerObject.transform.position);
        });
    }

    private static void GetLightObject(GameObject _myGameObject)
    {
        MyFlashLight = _myGameObject;
        MyFlashLight.SetActive(false);
    }
}
