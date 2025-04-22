using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        public GameObject Title;
        public GameObject Content;
        public GameObject LeftButton;
        public GameObject LeftButtonText;
        public GameObject RightButton;
        public GameObject RightButtonText;

        public GameObject StandingFullResetGood;
        public GameObject StandingFullResetBadTouching;
        public GameObject StandingFullResetBadSpreading;

        private Step m_currentStep;

        public void Start()
        {
            SetStep(new IntroductionStep(this));
        }

        private void SetStep(Step nextStep)
        {
            if (m_currentStep != null)
            {
                m_currentStep.OnExit();
            }

            nextStep.OnEnter();

            nextStep.UpdateTitle(Title.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateContent(Content.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateLeftButton(LeftButton.GetComponent<Button>(), LeftButtonText.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateRightButton(RightButton.GetComponent<Button>(), RightButtonText.GetComponent<TextMeshProUGUI>());

            m_currentStep = nextStep;
        }

        private enum Group : int
        {
            Introduction,
            AutomaticMounting,
            Done,
        }

        private abstract class Step
        {
            public virtual Group GetGroup()
            {
                return Group.Introduction;
            }

            public virtual void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = string.Empty;
            }

            public virtual void UpdateContent(TextMeshProUGUI content)
            {
                content.text = string.Empty;
            }

            public virtual void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                button.interactable = true;
                button.gameObject.SetActive(false);
            }

            public virtual void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                button.interactable = true;
                button.gameObject.SetActive(false);
            }

            public virtual void OnEnter()
            {
            }

            public virtual void OnExit()
            {
            }
        }

        private class IntroductionStep : Step
        {
            private readonly StepManager m_stepManager;

            public IntroductionStep(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override Group GetGroup()
            {
                return Group.Introduction;
            }

            public override void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = "Welcome to SlimeVR";
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text = "We will teach you how to use your trackers in VR";
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Next";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingIntroStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }
        }

        private abstract class AutomaticMountingStep : Step
        {
            public override Group GetGroup()
            {
                return Group.AutomaticMounting;
            }

            public override void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = "Automatic Mounting";
            }
        }

        private class AutomaticMountingIntroStep : AutomaticMountingStep
        {
            private readonly StepManager m_stepManager;

            public AutomaticMountingIntroStep(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text =
                    "Whenever you put on your trackers, you must go through Automatic Mounting\n\n" +
                    "<color=grey>Mounting tells SlimeVR where you've placed the trackers on your body";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Back";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new IntroductionStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Next";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep1(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }
        }

        private class AutomaticMountingStandingFullResetStep1 : AutomaticMountingStep
        {
            private readonly StepManager m_stepManager;

            public AutomaticMountingStandingFullResetStep1(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text =
                    "Standing Full Reset\n\n" +
                    "Stand up straight\n\n" +
                    "Keep the distance between your feet the same as your hip";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Back";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingIntroStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Next";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep2(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void OnEnter()
            {
                m_stepManager.StandingFullResetGood.SetActive(true);
                m_stepManager.StandingFullResetBadTouching.SetActive(true);
                m_stepManager.StandingFullResetBadSpreading.SetActive(true);
            }

            public override void OnExit()
            {
                m_stepManager.StandingFullResetGood.SetActive(false);
                m_stepManager.StandingFullResetBadTouching.SetActive(false);
                m_stepManager.StandingFullResetBadSpreading.SetActive(false);
            }
        }

        private class AutomaticMountingStandingFullResetStep2 : AutomaticMountingStep
        {
            private readonly StepManager m_stepManager;

            public AutomaticMountingStandingFullResetStep2(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text =
                    "Standing Full Reset\n\n" +
                    "Make sure your legs are as vertical as possible";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Back";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep1(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Next";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep3(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void OnEnter()
            {
                m_stepManager.StandingFullResetGood.SetActive(true);
                m_stepManager.StandingFullResetBadTouching.SetActive(true);
                m_stepManager.StandingFullResetBadSpreading.SetActive(true);
            }

            public override void OnExit()
            {
                m_stepManager.StandingFullResetGood.SetActive(false);
                m_stepManager.StandingFullResetBadTouching.SetActive(false);
                m_stepManager.StandingFullResetBadSpreading.SetActive(false);
            }
        }

        private class AutomaticMountingStandingFullResetStep3 : Step
        {
            private readonly StepManager m_stepManager;

            public AutomaticMountingStandingFullResetStep3(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override Group GetGroup()
            {
                return Group.AutomaticMounting;
            }

            public override void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = "Automatic Mounting";
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text =
                    "Standing Full Reset\n\n" +
                    "If possible, keep both your knees and feet pointing forward\n\n" +
                    "<color=grey>If you can't, prioritize your knees pointing forward! Your feet can point slightly inwards or outwards";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Back";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep2(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Next";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep4(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void OnEnter()
            {
                m_stepManager.StandingFullResetGood.SetActive(true);
                m_stepManager.StandingFullResetBadTouching.SetActive(true);
                m_stepManager.StandingFullResetBadSpreading.SetActive(true);
            }

            public override void OnExit()
            {
                m_stepManager.StandingFullResetGood.SetActive(false);
                m_stepManager.StandingFullResetBadTouching.SetActive(false);
                m_stepManager.StandingFullResetBadSpreading.SetActive(false);
            }
        }

        private class AutomaticMountingStandingFullResetStep4 : Step
        {
            private readonly StepManager m_stepManager;

            public AutomaticMountingStandingFullResetStep4(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override Group GetGroup()
            {
                return Group.AutomaticMounting;
            }

            public override void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = "Automatic Mounting";
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text =
                    "Standing Full Reset\n\n" +
                    "Now we're ready to do a full reset\n\n" +
                    "Press \"Reset\", look forward, and wait for 3 seconds";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Back";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep3(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Reset";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(async () =>
                {
                    button.interactable = false;

                    await Task.Delay(3000);

                    m_stepManager.SetStep(new DoneStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }

            public override void OnEnter()
            {
                m_stepManager.StandingFullResetGood.SetActive(true);
                m_stepManager.StandingFullResetBadTouching.SetActive(true);
                m_stepManager.StandingFullResetBadSpreading.SetActive(true);
            }

            public override void OnExit()
            {
                m_stepManager.StandingFullResetGood.SetActive(false);
                m_stepManager.StandingFullResetBadTouching.SetActive(false);
                m_stepManager.StandingFullResetBadSpreading.SetActive(false);
            }
        }

        private class DoneStep : Step
        {
            private readonly StepManager m_stepManager;

            public DoneStep(StepManager stepManager)
            {
                m_stepManager = stepManager;
            }

            public override Group GetGroup()
            {
                return Group.Introduction;
            }

            public override void UpdateTitle(TextMeshProUGUI title)
            {
                title.text = "Congratulations";
            }

            public override void UpdateContent(TextMeshProUGUI content)
            {
                content.text = "You're now ready to use your SlimeVR trackers!";
            }

            public override void UpdateLeftButton(Button button, TextMeshProUGUI content)
            {
                content.text = "Restart";

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    m_stepManager.SetStep(new AutomaticMountingStandingFullResetStep3(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }
        }
    }
}
