using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocalizator : MonoBehaviour
{
    [SerializeField, TextArea] private string _textEn;
    [Space(10)]
    [SerializeField, TextArea] private string _textRu;

    private TextMeshProUGUI _textMeshPro;


    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        Localize();
    }

    private void Localize()
    {
        if (YG2.envir.language == Language.Russian)
        {
            _textMeshPro.text = _textRu;
        }
        else
        {
            _textMeshPro.text = _textEn;
        }
    }
}
