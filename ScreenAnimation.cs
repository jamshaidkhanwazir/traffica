using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAnimation : MonoBehaviour
{
    public static void MoveScreen(RectTransform myRectTransform, float timeToAnimate, Vector3 startingPositin, Vector3 endingPosition, LeanTweenType myTweenType)
    {
        myRectTransform.position = startingPositin;
        LeanTween.move(myRectTransform, endingPosition, timeToAnimate).setEase(myTweenType);
    }
    public static void ScaleScreen(RectTransform myRectTransform, float timeToAnimate, Vector3 starting, Vector3 endingPosition, LeanTweenType myTweenType)
    {
        myRectTransform.localScale = starting;
        LeanTween.scale(myRectTransform, endingPosition, timeToAnimate).setEase(myTweenType);
    }
}
public enum ScreenAnimations
{
    None,
    MoveScreen,
    ScaleScreen
}
