using UnityEngine;
using YG;

public class SpriteLocalizator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteEn;
    [SerializeField] private SpriteRenderer _spriteRu;

    private void Awake()
    {
        if (YG2.envir.language == Language.Russian)
        {
            _spriteEn.gameObject.SetActive(false);
            _spriteRu.gameObject.SetActive(true);
        }
        else
        {
            _spriteEn.gameObject.SetActive(true);
            _spriteRu.gameObject.SetActive(false);
        }
    }
}
