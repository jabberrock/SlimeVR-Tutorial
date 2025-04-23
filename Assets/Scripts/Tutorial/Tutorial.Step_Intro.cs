public partial class Tutorial
{
    private class Step_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Welcome");
            dialog.SetContent("This tutorial will teach you how to use your SlimeVR trackers");
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }
}
