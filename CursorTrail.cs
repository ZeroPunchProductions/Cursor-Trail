using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    public Color trailColor = new Color(255, 255, 255);
    public float trailDistanceFromCam = 5;
    public float startTrailWidth = 0.1f;
    public float endTrailWidth = 0f;
    public float trailLife = 0.24f;

    Transform trailTrans;
    Camera mCam;

    // Start is called before the first frame update
    void Start()
    {
        mCam = GetComponent<Camera>();

        GameObject trailGameObject = new GameObject("Mouse Trail");
        trailTrans = trailGameObject.transform;
        TrailRenderer mouseTrail = trailGameObject.AddComponent<TrailRenderer>();
        mouseTrail.time = -1f;
        trailToCursorPos(Input.mousePosition);
        mouseTrail.time = trailLife;
        mouseTrail.startWidth = startTrailWidth;
        mouseTrail.endWidth = endTrailWidth;
        mouseTrail.numCapVertices = 2;
        mouseTrail.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        mouseTrail.sharedMaterial.color = trailColor;
    }

    // Update is called once per frame
    void Update()
    {
        trailToCursorPos(Input.mousePosition);
    }

    void trailToCursorPos(Vector3 screenPos)
    {
        trailTrans.position = mCam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, trailDistanceFromCam));
    }
}

