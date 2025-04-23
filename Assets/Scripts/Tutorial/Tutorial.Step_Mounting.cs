using System.Threading.Tasks;
using UnityEngine.UI;

partial class Tutorial
{
    private class Step_Mounting_Initial_MoveAround : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Stand up and move around a bit\n\n" +
                "<color=red>Notice that your body is twisted badly, and your legs don't move in the correct direction\n\n" +
                "<color=white>Let's fix this!");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Whenever you put on your trackers, you must go through Automatic Mounting\n\n" +
                "<color=grey>Automatic Mounting tells SlimeVR where the trackers have been placed on your body");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_Quick_StandingFullReset : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "The first step of Automatic Mounting is a standing reset\n\n" +
                "Stand up and face forward\n\n" +
                "Press \"Reset\", look straight forward, and wait for 3 seconds");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Reset", async () =>
            {
                dialog.RightButton.GetComponent<Button>().interactable = false;
                await Task.Delay(3000);
                tutorial.NextStep();
            });

            tutorial.StandingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullReset.SetActive(false);
        }
    }

    private class Step_Mounting_Quick_KneelingMountingReset : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "The second step of Automatic Mounting is a kneeling reset\n\n" +
                "Kneel on the floor and face forward\n\n" +
                "Press \"Reset\", look straight forward, and wait for 3 seconds");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Reset", async () =>
            {
                dialog.RightButton.GetComponent<Button>().interactable = false;
                await Task.Delay(3000);
                tutorial.NextStep();
            });

            tutorial.KneelingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.KneelingFullReset.SetActive(false);
        }
    }

    private class Step_Mounting_Quick_MoveAround : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Now stand up and move around a bit");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }

    private class Step_Mounting_Quick_Bad : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Better, but not great right?\n\n" +
                "Your body is facing the right way, but your legs don't move perfectly\n\n" +
                "Let's learn how to do a good Automatic Mounting");
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
            dialog.SetContent(
                "The first step of Automatic Mounting is a standing reset\n\n" +
                "<color=grey>The standing reset tells SlimeVR which way the tracker faces");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.StandingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullReset.SetActive(false);
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

            tutorial.StandingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullReset.SetActive(false);
        }
    }

    private class Step_Mounting_StandingFullReset_Reset : StepBehavior
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

            tutorial.StandingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.StandingFullReset.SetActive(false);
        }
    }

    private class Step_Mounting_KneelingMountingReset_Intro : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "The second step of Automatic Mounting is a kneeling reset\n\n" +
                "<color=grey>The kneeling reset tells SlimeVR how the tracker moves when rotated");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.KneelingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.KneelingFullReset.SetActive(false);
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

            tutorial.KneelingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.KneelingFullReset.SetActive(false);
        }
    }

    private class Step_Mounting_KneelingMountingReset_LeanForward: StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent("Lean forward, while keeping your back straight");
            dialog.SetLeftButton("Previous", tutorial.PreviousStep);
            dialog.SetRightButton("Next", tutorial.NextStep);

            tutorial.KneelingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.KneelingFullReset.SetActive(false);
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

            tutorial.KneelingFullReset.SetActive(true);
        }

        public override void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
            tutorial.KneelingFullReset.SetActive(false);
        }
    }
    private class Step_Mounting_Conclusion : StepBehavior
    {
        public override void Start(Tutorial tutorial, Dialog dialog)
        {
            dialog.Reset();
            dialog.SetTitle("Automatic Mounting");
            dialog.SetContent(
                "Stand up and move around a bit\n\n" +
                "Your in-game avatar should match your movements\n\n" +
                "<color=gray>Automatic Mounting takes some practice, but is critical for accurate tracking");
            dialog.SetLeftButton("Retry", () => tutorial.SetStep(Step.Mounting_StandingFullReset_Intro));
            dialog.SetRightButton("Next", tutorial.NextStep);
        }
    }
}
