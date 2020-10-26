using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    public ScreenAnimations MyAnimationType;
    public RectTransform MyRectTransform;
    public float TimeToAnimate;
    public Vector3 StartingValue;
    public Vector3 EndingValue;
    public LeanTweenType MyTweenType;

    private void OnEnable()
    {
        if (MyAnimationType == ScreenAnimations.MoveScreen)
        {
            ScreenAnimation.MoveScreen(MyRectTransform, TimeToAnimate, StartingValue, EndingValue, MyTweenType);
        }
        else if (MyAnimationType == ScreenAnimations.ScaleScreen)
        {
            ScreenAnimation.ScaleScreen(MyRectTransform, TimeToAnimate, StartingValue, EndingValue, MyTweenType);
        }
    }
}
