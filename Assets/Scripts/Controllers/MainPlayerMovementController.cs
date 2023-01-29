using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainPlayerMovementController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private Rigidbody playerRigidbody;
    [SerializeField]
    private float minVelocityForStoppingThePlane = 1f;
    [SerializeField]
    private float moveSpeed = 0.1f;

    [HideInInspector]
    public UnityEvent OnClick;
    [HideInInspector]
    public UnityEvent OnStartSwipe;
    [HideInInspector]
    public UnityEvent OnEndSwipe;

    private Vector3 startTouchPosition = Vector2.zero;
    private Vector3 endTouchPosition = Vector2.zero;
    private Vector3 directionOfSwipe = Vector3.zero;
    

    #region Input

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnStartSwipe.Invoke();
        //remember start position of touch
        startTouchPosition = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndSwipe.Invoke();
        //remember end touch position
        endTouchPosition = eventData.pointerCurrentRaycast.worldPosition;
        CalculateDirectionOfMove();
        MoveInDirection();
    }
    #endregion

    #region Methods
    private void CalculateDirectionOfMove()
    {
        var directionOfSwipe = endTouchPosition - startTouchPosition;
    }

    private void MoveInDirection()
    {
        playerRigidbody.AddForce(directionOfSwipe * moveSpeed, ForceMode.Force);
    }

    #endregion
}
