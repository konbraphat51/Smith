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
    private int excellentAreaWidthPoint = 3;
    private int excellentAreaCenterPoint = 80;

    [SerializeField] private GameObject rightEdgeObject;
    [System.NonSerialized] public float rightEdge;
    [SerializeField] private GameObject leftEdgeObject;
    [System.NonSerialized] public float leftEdge;

    [SerializeField] private GameObject reachedMovingMask;
    [SerializeField] private GameObject safeRectMask;
    [SerializeField] private GameObject excellentRectMask;

    [SerializeField] public bool goingRight;

    private void Start()
    {
        //get edge
        GetEdge();
    }

    private void Update()
    {
        Animate();
    }

    public void Initialize(int hittedPoint,
        int hittedPointMax,
        int safeAreaWidthPoint,
        int safeAreaCenterPoint,
        int excellentAreaWidthPoint,
        int excellentCenterPoint)
    {
        this.hittedPoint = hittedPoint;
        this.hittedPointMax = hittedPointMax;
        this.safeAreaWidthPoint = safeAreaWidthPoint;
        this.safeAreaCenterPoint = safeAreaCenterPoint;
        this.excellentAreaWidthPoint = excellentAreaWidthPoint;
        this.excellentAreaCenterPoint = excellentCenterPoint;

        showingRatio = GetRatio();

        //edit safe zone rect
        GetEdge();

        SetSafeAreaRect();

        //edit excellent zone rect
        SetExcellentAreaRect();
    }

    private void SetExcellentAreaRect()
    {
        float excellentAreaWidthRatio = (float)this.excellentAreaWidthPoint / (float)this.hittedPointMax;
        float excellentAreaCenterRatio = (float)this.excellentAreaCenterPoint / (float)this.hittedPointMax;

        float centerPosX = GetHorizontalPosition(excellentAreaCenterRatio);

        excellentRectMask.transform.localScale = new Vector2(excellentAreaWidthRatio, excellentRectMask.transform.localScale.y);
        excellentRectMask.transform.position = new Vector2(centerPosX, excellentRectMask.transform.position.y);
    }

    private void SetSafeAreaRect()
    {
        float safeAreaWidthRatio = (float)this.safeAreaWidthPoint / (float)this.hittedPointMax;
        float safeAreaCenterRatio = (float)this.safeAreaCenterPoint / (float)this.hittedPointMax;

        float centerPosX = GetHorizontalPosition(safeAreaCenterRatio);

        safeRectMask.transform.localScale = new Vector2(safeAreaWidthRatio, safeRectMask.transform.localScale.y);
        safeRectMask.transform.position = new Vector2(centerPosX, safeRectMask.transform.position.y);

    }

    private float GetHorizontalPosition(float ratio)
    {
        float output = 0f;

        switch (goingRight)
        {
            case false:
                //going left
                output = rightEdge - (rightEdge - leftEdge) * ratio;
                break;
            case true:
                //going right
                output = leftEdge + (rightEdge - leftEdge) * ratio;
                break;
        }

        return output;
    }

    private void GetEdge()
    {
        rightEdge = rightEdgeObject.transform.position.x;
        leftEdge = leftEdgeObject.transform.position.x;
    }

    public void UpdatePoint(int hittedPoint)
    {
        this.hittedPoint = hittedPoint;
        showingRatio = GetRatio();
    }

    private void Animate()
    {
        float edgePosX = GetHorizontalPosition(GetRatio());

        reachedMovingMask.transform.position = new Vector2(edgePosX, reachedMovingMask.transform.position.y);
    }

    private float GetRatio()
    {
        return (float)hittedPoint / (float)hittedPointMax;
    }
}
