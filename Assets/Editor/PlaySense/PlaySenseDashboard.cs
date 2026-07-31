using UnityEditor;
using UnityEngine;

public class PlaySenseDashboard : EditorWindow
{
    [MenuItem("Window/PlaySense/Dashboard")]
    public static void ShowWindow()
    {
        GetWindow<PlaySenseDashboard>("PlaySense");
    }

    private void OnGUI()
    {
        GUILayout.Label("PlaySense Dashboard");
    }
}