using System;

partial class Tutorial
{
    private class Step_Height_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Height");
            dialog.SetContent("Before we start, let's make sure your play space is set up correctly");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Height_SetHeight : StepBehavior
    {
        private const float EyeHeightToHeightRatio = 0.936f;
        private const float MeterToInches = 100.0f / 2.54f;

        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Height");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Save", tutorial.NextStep);
        }

        public override void Update(Tutorial tutorial, Dialog dialog)
        {
            var heightInMeters = tutorial.Camera.transform.position.y / EyeHeightToHeightRatio;

            var heightCm = (int)(heightInMeters * 100.0f);

            var heightInInches = (int)Math.Round(heightInMeters * MeterToInches);
            var heightFt = heightInInches / 12;
            var heightIn = heightInInches % 12;

            var heightStr = $"{heightFt}'{heightIn}\" ({heightCm} cm)";

            dialog.SetContent(
                "Check your height!\n\n" +
                "According to your VR headset, your height is:\n\n" +
                "<size=180%>" + heightStr + "<size=100%>\n\n" +
                "<color=red>If this is incorrect, please fix your play space and restart");
        }
    }
}