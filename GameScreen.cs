using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public ScreenAnimations MyAnimationType;
    public GameScreens MyName;
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
