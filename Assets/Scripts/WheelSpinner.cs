/*
Copyright (c) Mr BlckHrtzz
Let The Mind Dominate The Hrtzz
*/

using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WheelSpinner : MonoBehaviour
{

    #region Variables 
    public List<int> prize;
    public List<AnimationCurve> animationCurves;
    public float rotateSpeed = 600;
    float angleCoveredByOneItem;
    int itemNumber;
    bool isSpining = false;
    float maxAngle;
    float randomTime;
    #endregion

    #region Unity Functions

    void Start()
    {
        angleCoveredByOneItem = 360 / prize.Count;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isSpining)
        {
            randomTime = Random.Range(1, 4);
            itemNumber = Random.Range(0, prize.Count);
            maxAngle = 360 * randomTime + (itemNumber * angleCoveredByOneItem);
            Debug.Log(maxAngle);
            StartCoroutine(SpinTheWheel(5 * randomTime, maxAngle));
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        isSpining = true;

        float timer = 0.0f;
        float startAngle = transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);
        Debug.Log("Animation Curve No. : " + animationCurveNumber);

        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        isSpining = false;

        Debug.Log("Prize: " + prize[itemNumber]);
    }
}


    #endregion

    #region UserDefined

    #endregion


