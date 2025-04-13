#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class LevelButtonsGrid : MonoBehaviour
{
    [ContextMenu("Set Level Buttons")]
    public void SetLevelButtons()
    {
        Undo.RecordObject(this, "Set level buttons");

        LevelButton[] levelButtons = GetComponentsInChildren<LevelButton>();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].SetLevel(i + 1);
        }
        
        EditorUtility.SetDirty(this);
    }
}
#endif