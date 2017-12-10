/* 
*   Pedometer
*   Copyright (c) 2017 Yusuf Olokoba
*/

namespace PedometerU.Tests {

    using UnityEngine;
    using UnityEngine.UI;

    public class StepCounter : MonoBehaviour {

        public Text stepText;
        private Pedometer pedometer;
        GameFlowManager gfm;
        public int MinWalkSteps = 25;

        private void Start () {
            // Create a new pedometer
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);
            gfm = GameFlowManager.instance;
        }

        private void OnStep (int steps, double distance) {
            // Display the values // Distance in feet
            stepText.text = steps.ToString();
           // distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
            if(steps> MinWalkSteps)
            {
                gfm.EnableButtons();
            }
        }

        private void OnDisable () {
            // Release the pedometer
            pedometer.Dispose();
            pedometer = null;
        }


    }
}