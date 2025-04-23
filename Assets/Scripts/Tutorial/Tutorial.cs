using System.Collections.Generic;
using UnityEngine;

public partial class Tutorial : MonoBehaviour
{
    public GameObject Dialog;

    public GameObject StandingFullResetGood;
    public GameObject StandingFullResetBadTouching;
    public GameObject StandingFullResetBadSpreading;

    private enum Step : int
    {
        Intro,
        Mounting_Intro,
        Mounting_StandingFullReset_Intro,
        Mounting_StandingFullReset_StandUpStraight,
        Mounting_StandingFullReset_Reset,
        Mounting_KneelingMountingReset_Intro,
        Mounting_KneelingMountingReset_KneelOnGround,
        Mounting_KneelingMountingReset_Reset,
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
        { Step.Mounting_Intro,                                  new Step_Mounting_Intro() },
        { Step.Mounting_StandingFullReset_Intro,                new Step_Mounting_StandingFullReset_Intro() },
        { Step.Mounting_StandingFullReset_StandUpStraight,      new Step_Mounting_StandingFullReset_StandUpStraight() },
        { Step.Mounting_StandingFullReset_Reset,                new Step_Mounting_StandingFullReset_Reset() },
        { Step.Mounting_KneelingMountingReset_Intro,            new Step_Mounting_KneelingMountingReset_Intro() },
        { Step.Mounting_KneelingMountingReset_KneelOnGround,    new Step_Mounting_KneelingMountingReset_KneelOnGround() },
        { Step.Mounting_KneelingMountingReset_Reset,            new Step_Mounting_KneelingMountingReset_Reset() },
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
