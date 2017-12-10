using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetInput : MonoBehaviour {

    public Text debug;
    void Update()
    {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                TouchPhase phase = touch.phase;
                debug.text = phase.ToString();

                if (phase == TouchPhase.Began && GameFlowManager.instance.ScreenState == GameFlowManager.GameScreens.PetScreen)
                    Handheld.Vibrate();
                /*switch (phase)
                {
                    case TouchPhase.Began:
                        print("New touch detected at position " + touch.position + " , index " + touch.fingerId);
                        break;
                    case TouchPhase.Moved:
                        print("Touch index " + touch.fingerId + " has moved by " + touch.deltaPosition);
                        break;
                    case TouchPhase.Stationary:
                        print("Touch index " + touch.fingerId + " is stationary at position " + touch.position);
                        break;
                    case TouchPhase.Ended:
                        print("Touch index " + touch.fingerId + " ended at position " + touch.position);
                        break;
                    case TouchPhase.Canceled:
                        print("Touch index " + touch.fingerId + " cancelled");
                        break;
                }*/
            }
        }
    }
}
