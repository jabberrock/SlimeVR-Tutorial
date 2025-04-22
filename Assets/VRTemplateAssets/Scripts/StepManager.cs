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

        public void Start()
        {
            SetStep(new IntroductionStep(this));
        }

        private void SetStep(Step nextStep)
        {
            nextStep.UpdateTitle(Title.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateContent(Content.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateLeftButton(LeftButton.GetComponent<Button>(), LeftButtonText.GetComponent<TextMeshProUGUI>());
            nextStep.UpdateRightButton(RightButton.GetComponent<Button>(), RightButtonText.GetComponent<TextMeshProUGUI>());
        }
        
        private enum Group : int
        {
            Introduction,
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
                button.gameObject.SetActive(false);
            }

            public virtual void UpdateRightButton(Button button, TextMeshProUGUI content)
            {
                button.gameObject.SetActive(false);
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
                    m_stepManager.SetStep(new DoneStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
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
                    m_stepManager.SetStep(new IntroductionStep(m_stepManager));
                });

                button.gameObject.SetActive(true);
            }
        }
    }
}
