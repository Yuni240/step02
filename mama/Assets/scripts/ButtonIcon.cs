using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonIcon : MonoBehaviour
{

    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuilIndex;

    private void Awake()
    {
       // PlayerPrefs.DeleteAll(); // try

        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.endManager.LvlUnlock, firstLevelBuilIndex);

        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + firstLevelBuilIndex <= unlockedLvl)
            {
                lvlButton[i].interactable = true;
                lvlButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();

                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else
            {

                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite = lockedIcon;

                lvlButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        // Update is called once per frame
        void Update()
        {

        }
    }
}