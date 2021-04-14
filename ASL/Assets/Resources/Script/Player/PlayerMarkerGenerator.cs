using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerGenerator : MonoBehaviour
{
    private GameObject SelectedMap;
    public Camera PlayerCamera;
    private static GameObject MarkerObject;
    private bool OneMarker = false;
    public static List<GameObject> PlayerSetMarker = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SelectObjectByClick();
    }

    private void SelectObjectByClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray MouseRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(MouseRay, out Hit))
            {
                if (Hit.collider.tag == "Chunk")
                {
                    ASL.ASLHelper.InstantiateASLObject("Marker", Hit.point, Quaternion.identity, "", "", GetHoldObject);
                }
                else
                {
                    return;
                }
            }
        }
    }

    private static void GetHoldObject(GameObject _myGameObject)
    {
        MarkerObject = _myGameObject;
        PlayerSetMarker.Add(_myGameObject);
    }
}
