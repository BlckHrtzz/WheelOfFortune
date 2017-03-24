/*
Copyright (c) Mr BlckHrtzz
Let The Mind Dominate The Hrtzz
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSpinnerV2 : MonoBehaviour
{

    #region Variables 
    public List<int> prizesAvailable;       //List of items Available
    float angleCoveredByOneItem;            //Angle Covered by per item in the list.
    int prizeNumber;                        //The number of prize.
    bool isSpining = false;                 
    bool stopSpinning = false;              
    float calculatedAngle = 0f;             //Finale Angle calculated when user prvides the input.
    float rotateSpeed = 15f;                //The speed at which the wheel will rotate.

    bool buttonPressed = false;             //To check if the button is pressed or not.
    public Button button;                   //public reference for getting button.
    Text buttonText;                        //Refernce of text in button.
    public Text score;                      //public reference for getting Score.

    #endregion

    #region Unity Functions

    void Start()
    {
        angleCoveredByOneItem = 360 / prizesAvailable.Count;        //Caculating angle cover by each item;
        buttonText = button.GetComponentInChildren<Text>();
        score.text = score.text = "Won : 0 $";                      //Default Text for Score.
        ;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump") && !isSpining)
        if (buttonPressed && !isSpining)
        {
            prizeNumber = Random.Range(0, prizesAvailable.Count);               //Getting any random item available from list.
            calculatedAngle = 360 + (prizeNumber * angleCoveredByOneItem);      //Calculating the finale angle for the random item.
            Debug.Log("The Angle is : " + calculatedAngle + " The Item is : " + prizeNumber + " The Prize is : " + prizesAvailable[prizeNumber]);
            isSpining = true;               
            buttonPressed = false;
            buttonText.text = "Stop";
        }
        else
        //if (Input.GetButtonDown("Jump") && isSpining)
        if (buttonPressed && isSpining)
        {
            stopSpinning = true;
            buttonPressed = false;
            buttonText.text = "Start";
            button.interactable = false;
        }

        //Spinning The Wheel.
        if (isSpining)
        {
            transform.Rotate(Vector3.forward, rotateSpeed);
        }

        //Stopping The wheel.
        if (stopSpinning)
        {
            if (rotateSpeed > 0)
            {
                rotateSpeed = rotateSpeed - (Time.deltaTime * 3);       //sSlowing Down the speed of wheel.
            }
            else
                if (rotateSpeed < 0)
            {
                isSpining = false;
                transform.eulerAngles = new Vector3(0.0f, 0.0f, calculatedAngle);
                stopSpinning = false;         //Resetting the Values.
                rotateSpeed = 15f;            //Resetting the Values.
                button.interactable = true;   //Resetting the Values.
                score.text = "Won : " + prizesAvailable[prizeNumber] + "$";
            }

        }

    }

    #endregion

    #region UserDefined
    //To Get the input from Button.
    public void ButtonStatus()
    {
        buttonPressed = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

}
