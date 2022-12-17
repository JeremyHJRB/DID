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
        // click atas button
        atasButton.onClick.AddListener(OnAtasButtonClick);
        // click bawah button
        bawahButton.onClick.AddListener(OnBawahButtonClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            OnBawahButtonClick();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            OnAtasButtonClick();
        }
    }

    private void OnAtasButtonClick()
    {
        if (choice + 1 > 1) return;
        choice++;
        
        choiceWindow.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 50);
    }

    private void OnBawahButtonClick()
    {
        if (choice - 1 < 0) return;
        choice--;
        
        choiceWindow.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -50);
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
