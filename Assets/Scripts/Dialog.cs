using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject Title;
    public GameObject Content;
    public GameObject LeftButton;
    public GameObject LeftButtonText;
    public GameObject RightButton;
    public GameObject RightButtonText;

    public void Reset()
    {
        Title.SetActive(false);
        
        Content.SetActive(false);
        
        LeftButton.SetActive(false);
        LeftButton.GetComponent<Button>().interactable = true;
        LeftButton.GetComponent<Button>().onClick.RemoveAllListeners();

        RightButton.SetActive(false);
        RightButton.GetComponent<Button>().interactable = true;
        RightButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public void SetTitle(string text)
    {
        Title.SetActive(true);
        Title.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetContent(string text)
    {
        Content.SetActive(true);
        Content.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetLeftButton(string text, UnityAction call)
    {
        LeftButton.SetActive(true);
        LeftButton.GetComponent<Button>().onClick.AddListener(call);
        LeftButtonText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetRightButton(string text, UnityAction call)
    {
        RightButton.SetActive(true);
        RightButton.GetComponent<Button>().onClick.AddListener(call);
        RightButtonText.GetComponent<TextMeshProUGUI>().text = text;
    }
}
