using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawRoute : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject MyBrush;
    private float BrushSize = 0.1f;
    public static List<GameObject> MyBrushList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DrawTheLine();
    }

    private void DrawTheLine()
    {
        if (Input.GetMouseButton(1))
        {
            Ray MouseRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(MouseRay, out Hit))
            {
                if (Hit.collider.tag == "WhiteBoard")
                {
                    ASL.ASLHelper.InstantiateASLObject("Brush", Hit.point, Quaternion.identity, "", "", GetEachBrush);
                }
            }
        }
    }

    private static void GetEachBrush(GameObject _myGameObject)
    {
        //MyBrushList.Add(_myGameObject);
    }
}
