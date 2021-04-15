using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ASL;

public class PlayerMinimap : MonoBehaviour
{
    public Camera mapCam = null;
    public Transform table = null;
    private static GameObject MyIndicator;
    private static bool IsActive = false;
    private static Color IndicatorColor;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mapCam != null);
        Debug.Assert(table != null);

        ASLHelper.InstantiateASLObject(PrimitiveType.Sphere, new Vector3(gameObject.transform.localPosition.x,
            table.localPosition.y + 9f, gameObject.transform.localPosition.z), Quaternion.identity, "", "", IndicatorCallback);
    }

    // Update is called once per frame
    void Update()
    {
        //mapCam.gameObject.transform.position = new Vector3(0, 50f, 0);
        if (IsActive)
        {
            MyIndicator.GetComponent<ASLObject>().SendAndSetClaim(() =>
            {
                MyIndicator.GetComponent<ASLObject>().SendAndSetLocalPosition(new Vector3(gameObject.transform.localPosition.x,
                    table.localPosition.y + 9f, gameObject.transform.localPosition.z));
            });

            mapCam.gameObject.transform.rotation.Set(90, 0, 0, 1);
            mapCam.gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x,
                table.localPosition.y + 10f, gameObject.transform.localPosition.z);
        }
    }

    public void ToggleMinimap() {
        if (mapCam.gameObject.activeSelf)
        {
            mapCam.gameObject.SetActive(false);
        } else
        {
            mapCam.gameObject.SetActive(true);
        }
    }

    static void IndicatorCallback(GameObject _indicator)
    {
        MyIndicator = _indicator;
        MyIndicator.layer = 9;
        MyIndicator.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        MyIndicator.GetComponent<Collider>().enabled = false;

        IndicatorColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);

        MyIndicator.GetComponent<ASLObject>().SendAndSetClaim(() =>
        {
            MyIndicator.GetComponent<ASLObject>().SendAndSetObjectColor(IndicatorColor, IndicatorColor);
            MyIndicator.GetComponent<ASLObject>().SendAndSetLocalScale(new Vector3(3f, .5f, 3f));
        });

        IsActive = true;
    }
}
