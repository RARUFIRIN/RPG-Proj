using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject GPlayer;

    float HWidth;
    float HHeight;
    float MinX, MaxX, MinY, MaxY;
    void Start()
    {
        GPlayer = GameObject.Find("Player");
        HWidth = Camera.main.aspect * Camera.main.orthographicSize;
        HHeight = Camera.main.orthographicSize;
        MinX = -1; MinY = -7;
        MaxX = 51; MaxY = 10;
    }


    void Update()
    {
        Vector3 LimitPos = new Vector3(
            Mathf.Clamp(GPlayer.transform.position.x, MinX + HWidth, MaxX - HWidth), 
            Mathf.Clamp(GPlayer.transform.position.y, MinY + HHeight, MaxY - HHeight),
            -10);
        transform.position = Vector3.Lerp(transform.position, LimitPos, Time.deltaTime * 4.0f);
    }
}
