public partial class Tutorial
{
    private class Step_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Welcome to SlimeVR");
            dialog.SetContent("We will teach you how to use your trackers in VR");
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }
}
