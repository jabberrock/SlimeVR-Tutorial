using System.Threading.Tasks;
using UnityEngine.UI;

partial class Tutorial
{
    private class Step_Mounting_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Whenever you put on your trackers, you must go through Automatic Mounting\n\n" +
                "<color=grey>Automatic Mounting tells SlimeVR where you've placed the trackers on your body");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_StandingFullReset_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent("The first step of Automatic Mounting is a standing reset");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.StandingFullResetGood.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullResetGood.SetActive(false);
        }
    }

    private class Step_Mounting_StandingFullReset_StandUpStraight : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Stand up straight\n\n" +
                "Keep the distance between your feet the same as your hip");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.StandingFullResetGood.SetActive(true);
            tutorial.StandingFullResetBadTouching.SetActive(true);
            tutorial.StandingFullResetBadSpreading.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullResetGood.SetActive(false);
            tutorial.StandingFullResetBadTouching.SetActive(false);
            tutorial.StandingFullResetBadSpreading.SetActive(false);
        }
    }

    private class Step_Mounting_StandingFullReset_Reset  : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "You're now ready to do do the standing reset\n\n" +
                "Press \"Reset\", look straight forward, and wait for 3 seconds");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Reset", async () =>
            {
                dialog.RightButton.GetComponent<Button>().interactable = false;
                await Task.Delay(3000);
                tutorial.NextStep();
            });

            tutorial.StandingFullResetGood.SetActive(true);
            tutorial.StandingFullResetBadTouching.SetActive(true);
            tutorial.StandingFullResetBadSpreading.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullResetGood.SetActive(false);
            tutorial.StandingFullResetBadTouching.SetActive(false);
            tutorial.StandingFullResetBadSpreading.SetActive(false);
        }
    }

    private class Step_Mounting_KneelingMountingReset_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent("The second step of Automatic Mounting is a kneeling reset");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_KneelingMountingReset_KneelOnGround : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Kneel on the ground\n\n" +
                "Keep the distance between your knees, and distance between your feet the same as your hip");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_KneelingMountingReset_Reset : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "You're now ready to do do the kneeling reset\n\n" +
                "Press \"Reset\", look straight forward, and wait for 3 seconds");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Reset", async () =>
            {
                dialog.RightButton.GetComponent<Button>().interactable = false;
                await Task.Delay(3000);
                tutorial.NextStep();
            });
        } 
    }
}
