using UnityEngine;

public class ScreenAnimation : MonoBehaviour
{
    public static void MoveScreen(RectTransform myRectTransform, float timeToAnimate, Vector3 startingPosition, Vector3 endingPosition, LeanTweenType myTweenType)
    {
        myRectTransform.position = startingPosition;
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
