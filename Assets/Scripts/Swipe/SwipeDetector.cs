using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] private Vector2 leftUpBound;
    [SerializeField] private Vector2 rightDownBound;
    [SerializeField] private float minDistanceForSwipe;

    public delegate void Swipe();
    public event Swipe OnSwipe;

    public delegate void Click();
    public event Swipe OnClick;

    private void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (fingerDownPosition.x > leftUpBound.x && fingerDownPosition.x < rightDownBound.x &&
            fingerDownPosition.y < leftUpBound.y && fingerDownPosition.y > rightDownBound.y)
        {
            if (fingerUpPosition.y - fingerDownPosition.y > minDistanceForSwipe)
            {
                OnSwipe?.Invoke();
            }
            else if (fingerUpPosition.y - fingerDownPosition.y >= 0)
            {
                OnClick?.Invoke();
            }
        }
    }
}
