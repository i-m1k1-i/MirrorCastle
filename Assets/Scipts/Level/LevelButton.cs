using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private TextMeshProUGUI _levelText;

    private Button _button;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadLevel);
        _button.interactable = YG2.saves.UnlockedLevel >= _levelNumber;
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(Level.NamePrefix + _levelNumber);
    }

    public void SetLevel(int level)
    {
        _levelNumber = level;
        _levelText.text = level.ToString();
    }
}
