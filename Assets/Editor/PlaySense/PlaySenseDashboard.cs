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
        GUILayout.Space(10);

        GUILayout.Label(
            "PlaySense Dashboard",
            EditorStyles.boldLabel);

        GUILayout.Space(15);

        GUILayout.Label("No session loaded.");
    }
}