using System;
using System.Threading.Tasks;
using UnityEngine.UI;

public partial class Tutorial
{
    private class Step_Trackers_TurnOnAndCalibrate : StepBehavior
    {
        private DateTime m_startTime;

        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Trackers");
            dialog.SetContent(
                "Turn on your trackers\n\n" +
                "Leave them on a flat surface for 30 seconds to calibrate");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            dialog.RightButton.GetComponent<Button>().interactable = false;

            m_startTime = DateTime.Now;
        }

        public override void Update(Tutorial tutorial, Dialog dialog)
        {
            if (DateTime.Now > m_startTime.AddSeconds(5.0))
            {
                dialog.RightButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    private class Step_Trackers_PutOnBody : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Trackers");
            dialog.SetContent(
                "Please put on your trackers\n\n" +
                "We recommend placing the trackers in these positions, so that they don't shift during play");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.TrackerPositions.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.TrackerPositions.SetActive(false);
        }
    }
}
