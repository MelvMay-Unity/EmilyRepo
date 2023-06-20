using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class DeathDealer : MonoBehaviour
{
    public LayerMask HitLayers;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= OnFingerDown;        
    }

    void OnFingerDown(Finger finger)
    {
        var position = Camera.main.ScreenToWorldPoint(finger.screenPosition);
       
        var collider = Physics2D.OverlapPoint(position, HitLayers);

        if (collider)
        {
            Destroy(collider.gameObject);
        }
    }
}
