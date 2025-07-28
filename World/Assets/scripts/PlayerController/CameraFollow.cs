using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 Coord = new Vector3(0, 0, -1);
    // Update is called once per frame
    void Update()
    {
        Coord.x = PlayerTransform.position.x;
        Coord.y = PlayerTransform.position.y;

        this.transform.position = Coord;
    }
}
