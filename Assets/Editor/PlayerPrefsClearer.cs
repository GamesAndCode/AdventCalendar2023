using UnityEditor;
using UnityEngine;

public class PlayerPrefsClearer : EditorWindow
{
    [MenuItem("Window/Clear PlayerPrefs")]
    static void Init()
    {
        UnityEngine.PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs cleared!");
    }
}