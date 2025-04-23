using System.Collections.Generic;
using UnityEngine;

public partial class Tutorial : MonoBehaviour
{
    public GameObject SlimeVRClient;

    public GameObject Camera;
    public GameObject Dialog;

    public GameObject TrackerPositions;
    public GameObject StandingFullReset;
    public GameObject KneelingFullReset;

    private enum Step : int
    {
        Intro,
        Height_Intro,
        Height_SetHeight,
        Trackers_TurnOnAndCalibrate,
        Trackers_PutOnBody,
        Mounting_Initial_MoveAround,
        Mounting_Intro,
        Mounting_Quick_StandingFullReset,
        Mounting_Quick_KneelingMountingReset,
        Mounting_Quick_MoveAround,
        Mounting_Quick_Bad,
        Mounting_StandingFullReset_Intro,
        Mounting_StandingFullReset_StandUpStraight,
        Mounting_StandingFullReset_Reset,
        Mounting_KneelingMountingReset_Intro,
        Mounting_KneelingMountingReset_KneelOnGround,
        Mounting_KneelingMountingReset_LeanForward,
        Mounting_KneelingMountingReset_Reset,
        Mounting_Conclusion,
        Done,
    }

    private abstract class StepBehavior
    {
        public virtual void Start(Tutorial tutorial, Dialog dialog)
        {
        }

        public virtual void Update(Tutorial tutorial, Dialog dialog)
        {
        }

        public virtual void OnDestroy(Tutorial tutorial, Dialog dialog)
        {
        }
    }

    private static readonly Dictionary<Step, StepBehavior> StepBehaviors = new()
    {
        { Step.Intro,                                           new Step_Intro() },
        { Step.Height_Intro,                                    new Step_Height_Intro() },
        { Step.Height_SetHeight,                                new Step_Height_SetHeight() },
        { Step.Trackers_TurnOnAndCalibrate,                     new Step_Trackers_TurnOnAndCalibrate() },
        { Step.Trackers_PutOnBody,                              new Step_Trackers_PutOnBody() },
        { Step.Mounting_Initial_MoveAround,                     new Step_Mounting_Initial_MoveAround() },
        { Step.Mounting_Intro,                                  new Step_Mounting_Intro() },
        { Step.Mounting_Quick_StandingFullReset,                new Step_Mounting_Quick_StandingFullReset() },
        { Step.Mounting_Quick_KneelingMountingReset,            new Step_Mounting_Quick_KneelingMountingReset() },
        { Step.Mounting_Quick_MoveAround,                       new Step_Mounting_Quick_MoveAround() },
        { Step.Mounting_Quick_Bad,                              new Step_Mounting_Quick_Bad() },
        { Step.Mounting_StandingFullReset_Intro,                new Step_Mounting_StandingFullReset_Intro() },
        { Step.Mounting_StandingFullReset_StandUpStraight,      new Step_Mounting_StandingFullReset_StandUpStraight() },
        { Step.Mounting_StandingFullReset_Reset,                new Step_Mounting_StandingFullReset_Reset() },
        { Step.Mounting_KneelingMountingReset_Intro,            new Step_Mounting_KneelingMountingReset_Intro() },
        { Step.Mounting_KneelingMountingReset_KneelOnGround,    new Step_Mounting_KneelingMountingReset_KneelOnGround() },
        { Step.Mounting_KneelingMountingReset_LeanForward,      new Step_Mounting_KneelingMountingReset_LeanForward() },
        { Step.Mounting_KneelingMountingReset_Reset,            new Step_Mounting_KneelingMountingReset_Reset() },
        { Step.Mounting_Conclusion,                             new Step_Mounting_Conclusion() },
        { Step.Done,                                            new Step_Done() },
    };

    private Step m_currentStep = Step.Intro;

    public void Start()
    {
        StepBehaviors[m_currentStep].Start(this, Dialog.GetComponent<Dialog>());
    }

    private void Update()
    {
        StepBehaviors[m_currentStep].Update(this, Dialog.GetComponent<Dialog>());
    }

    private void SetStep(Step nextStep)
    {
        StepBehaviors[m_currentStep].OnDestroy(this, Dialog.GetComponent<Dialog>());

        m_currentStep = nextStep;
        StepBehaviors[m_currentStep].Start(this, Dialog.GetComponent<Dialog>());
    }

    private void PreviousStep()
    {
        var nextStep = m_currentStep - 1;
        if (nextStep >= Step.Intro && nextStep <= Step.Done)
        {
            SetStep(nextStep);
        }
    }

    private void NextStep()
    {
        var nextStep = m_currentStep + 1;
        if (nextStep >= Step.Intro && nextStep <= Step.Done)
        {
            SetStep(nextStep);
        }
    }
}
