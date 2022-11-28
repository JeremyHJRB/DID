using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] Button atasButton;
    [SerializeField] Button bawahButton;

    int choice = 0;

    [SerializeField] GameObject choiceWindow;
    // Start is called before the first frame update
    private void Start()
    {
        atasButton.onClick.AddListener(OnAtasButtonClick);
        bawahButton.onClick.AddListener(OnBawahButtonClick);
        choiceWindow.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    private void OnAtasButtonClick()
    {
        if (choice + 1 > 1) return;
        choice++;
        
        choiceWindow.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 50);
        choiceWindow.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
        ResetColor();
    }

    private void OnBawahButtonClick()
    {
        if (choice - 1 < 0) return;
        choice--;
        
        choiceWindow.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -50);
        choiceWindow.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
        ResetColor();
    }

    private void ResetColor()
    {
        for (int i = 0; i < choiceWindow.transform.GetChild(0).childCount; i++)
        {
            if (i == choice) continue;

            choiceWindow.transform.GetChild(0).GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
    // Update is called once per frame
}
