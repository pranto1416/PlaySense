using UnityEditor;
using UnityEngine;
using System.IO;
using PlaySense.Export;

public class PlaySenseDashboard : EditorWindow
{
    [MenuItem("Window/PlaySense/Dashboard")]
    public static void ShowWindow()
    {
        GetWindow<PlaySenseDashboard>("PlaySense");
    }

    private Vector2 scroll;

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.Label("PlaySense Dashboard", EditorStyles.boldLabel);

        GUILayout.Space(10);

        string[] sessions = SessionStorage.GetSessionFiles();

        GUILayout.Label($"Sessions Found: {sessions.Length}");

        GUILayout.Space(5);

        scroll = GUILayout.BeginScrollView(scroll);

        foreach (string sessionPath in sessions)
        {
            GUILayout.Label(Path.GetFileNameWithoutExtension(sessionPath));

            GUILayout.BeginVertical("box");

            GUILayout.Label(Path.GetFileNameWithoutExtension(sessionPath), EditorStyles.boldLabel);

            GUILayout.Space(4);

            GUILayout.Label("Scene: Unknown");

            GUILayout.Label("Duration: --");

            GUILayout.Label(" Distance: --");

            GUILayout.Space(6);

            GUILayout.BeginHorizontal();

            if(GUILayout.Button("Open"))
            {
                var session = SessionStorage.Load(sessionPath);

                if(session != null){
                    Debug.Log("========== PLAYSENSE ==========");
                    Debug.Log($"Scene: {session.SceneName}");
                    Debug.Log($"Frames: {session.Frames.Count}");
                    Debug.Log($"Events: {session.Events.Count}");
                    Debug.Log($"Duration: {session.Duration}");
                }
            }

            GUILayout.Button("Delete");

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUILayout.Space(8);

            GUILayout.Label(Path.GetFileName(sessionPath));

        }

        GUILayout.EndScrollView();
    }
}