using UnityEngine;

public partial class Tutorial
{
    private class Step_Done : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Congratulations!");
            dialog.SetContent("You are now ready to use your SlimeVR trackers!");
            dialog.SetLeftButton("Restart", () => tutorial.SetStep(Step.Intro));
            dialog.SetRightButton("Exit", () => Application.Quit());
        }
    }
}
