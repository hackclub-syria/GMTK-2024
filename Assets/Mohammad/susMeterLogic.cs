using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class susMeterLogic : MonoBehaviour
{
    public Slider susSlider;
    public float crowdIQ;
    public float susValue;
    
   public void changeSusValue(float susChange){
    susValue += susChange;
    susSlider.value = susValue;
   }



   public float susAmmoutOfChange(float initialHoleSize, float currentHoleSize){
    float value;
    value = Math.Abs((currentHoleSize-0.5f) + (currentHoleSize- currentHoleSize) )/2;
    return value*crowdIQ;
   }



   public void susMeter(float initialHoleSize, float currentHoleSize ){
    float susChange = susAmmoutOfChange(initialHoleSize , currentHoleSize);
    changeSusValue(susChange);
     
   }
}
