using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgingGauge : MonoBehaviour
{
    private int hittedPoint = 0;
    private int hittedPointMax = 100;

    [SerializeField] private float fillingSpeed = 0.001f;
    //where Fill comes until
    private float showingRatio = 0f;

    private int safeAreaWidthPoint = 10;
    private int safeAreaCenterPoint = 80;

    [SerializeField] private GameObject rightEdgeObject;
    [System.NonSerialized] public float rightEdge;
    [SerializeField] private GameObject leftEdgeObject;
    [System.NonSerialized] public float leftEdge;

    [SerializeField] private GameObject reachedMovingMask;
    [SerializeField] private GameObject safeRectMask;

    [SerializeField] public bool goingRight;

    private void Start()
    {
        //get edge
        rightEdge = rightEdgeObject.transform.position.x;
        leftEdge = leftEdgeObject.transform.position.x;
    }

    private void Update()
    {
        Animate();
    }

    public void Initialize(int hittedPoint,
        int hittedPointMax,
        int safeAreaWidthPoint,
        int safeAreaCenterPoint)
    {
        this.hittedPoint = hittedPoint;
        this.hittedPointMax = hittedPointMax;
        this.safeAreaWidthPoint = safeAreaWidthPoint;
        this.safeAreaCenterPoint = safeAreaCenterPoint;

        showingRatio = GetRatio();

        //edit safe zone rect
        float safeAreaWidthRatio = (float)this.safeAreaWidthPoint / (float)this.hittedPointMax;
        float safeAreaCenterRatio = (float)this.safeAreaCenterPoint / (float)this.hittedPointMax;

        float centerPosX = 0f;
        switch (goingRight)
        {
            case false:
                //going left
                centerPosX = rightEdge - (rightEdge - leftEdge) * safeAreaCenterRatio;
                break;
            case true:
                centerPosX = leftEdge + (rightEdge - leftEdge) * safeAreaCenterRatio;
                break;
        }

        safeRectMask.transform.localScale = new Vector2(safeAreaWidthRatio, safeRectMask.transform.localScale.y);
        safeRectMask.transform.position = new Vector2(centerPosX, safeRectMask.transform.position.y);
    }

    public void UpdatePoint(int hittedPoint)
    {
        this.hittedPoint = hittedPoint;
        showingRatio = GetRatio();
    }

    private void Animate()
    {
        float edgePosX = 0f;

        switch (goingRight)
        {
            case false:
                //going left
                edgePosX = rightEdge - (rightEdge - leftEdge) * GetRatio();
                break;
            case true:
                edgePosX = leftEdge + (rightEdge - leftEdge) * GetRatio();
                break;
        }

        reachedMovingMask.transform.position = new Vector2(edgePosX, reachedMovingMask.transform.position.y);
    }

    private float GetRatio()
    {
        return (float)hittedPoint / (float)hittedPointMax;
    }
}
