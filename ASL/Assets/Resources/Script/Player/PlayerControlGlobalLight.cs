using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlGlobalLight : MonoBehaviour
{
    //X represent east west, Light rotate at Z direction
    public Quaternion LightRotation;
    //private static GameObject MyDirectionalLight;
    public Slider LightSlider;
    public Light MyDirectionalLight;

    void Start()
    {
        LightRotation = Quaternion.Euler(90, 0, 0);
        //ASL.ASLHelper.InstantiateASLObject("Directional Light", new Vector3(0, 60, 0), LightRotation, "", "", GetLightObject);
    }

    void Update()
    {
    }

    //private static void GetLightObject(GameObject _myGameObject)
    //{
    //    MyDirectionalLight = _myGameObject;
    //}

    //Change direction of the light for all the user.
    public void SetLight()
    {
        LightRotation = Quaternion.Euler(LightSlider.value, 0, 0);
        Debug.Log(LightRotation);
        //MyDirectionalLight.transform.rotation = LightRotation;
        MyDirectionalLight.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
        {
            MyDirectionalLight.GetComponent<ASL.ASLObject>().SendAndSetWorldRotation(LightRotation);
        });
    }
}
