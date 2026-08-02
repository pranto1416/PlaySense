using UnityEditor;
using UnityEngine;
using System.IO;
using PlaySense.Export;
using PlaySense.Data.Models;

public class PlaySenseDashboard : EditorWindow
{
    private Vector2 sessionScroll;
    private SessionData selectedSession;
    private string selectedPath;

    [MenuItem("Window/PlaySense/Dashboard")]
    public static void ShowWindow()
    {
        GetWindow<PlaySenseDashboard>("PlaySense");
    }

    private void OnGUI()
    {
        DrawHeader();

        GUILayout.BeginHorizontal();

        DrawSessionList();

        GUILayout.Space(8);

        DrawDetailsPanel();

        GUILayout.EndHorizontal();
    }

    private void DrawHeader()
    {
        GUILayout.Space(8);

        GUIStyle title = new GUIStyle(EditorStyles.boldLabel);
        title.fontSize = 18;
        title.alignment = TextAnchor.MiddleCenter;

        GUILayout.Label("🎮 PlaySense Dashboard", title);

        GUILayout.Space(5);

        EditorGUILayout.HelpBox(
            "Gameplay Analytics & Session Viewer",
            MessageType.Info);

        GUILayout.Space(8);
    }

    private void DrawSessionList()
    {
        GUILayout.BeginVertical("box", GUILayout.Width(340));

        GUILayout.Label("Sessions", EditorStyles.boldLabel);

        string[] sessions = SessionStorage.GetSessionFiles();

        GUILayout.Label($"Found {sessions.Length} Session(s)");

        GUILayout.Space(8);

        sessionScroll = GUILayout.BeginScrollView(sessionScroll);

        foreach (string path in sessions)
        {
            SessionData session = SessionStorage.Load(path);

            if (session == null)
                continue;

            GUILayout.BeginVertical("box");

            GUILayout.Label(
                "📄 " + Path.GetFileNameWithoutExtension(path),
                EditorStyles.boldLabel);

            GUILayout.Space(4);

            GUILayout.Label($"🎬 Scene      : {session.SceneName}");
            GUILayout.Label($"⏱ Duration   : {session.Metrics.Duration:F2} sec");
            GUILayout.Label($"🚶 Distance   : {session.Metrics.TotalDistance:F2} m");
            GUILayout.Label($"🎞 Frames     : {session.Metrics.FrameCount}");
            GUILayout.Label($"🎯 Events     : {session.Events.Count}");

            GUILayout.Space(6);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("👁 View"))
            {
                selectedSession = session;
                selectedPath = path;
            }

            GUILayout.Button("📤 Export");

            if (GUILayout.Button("🗑 Delete"))
            {
                if (EditorUtility.DisplayDialog(
                    "Delete Session",
                    $"Delete\n\n{Path.GetFileName(path)} ?",
                    "Delete",
                    "Cancel"))
                {
                    File.Delete(path);

                    if (selectedPath == path)
                    {
                        selectedSession = null;
                        selectedPath = "";
                    }

                    AssetDatabase.Refresh();
                    Repaint();
                    return;
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUILayout.Space(8);
        }

        GUILayout.EndScrollView();

        GUILayout.EndVertical();
    }

    private void DrawDetailsPanel()
    {
        GUILayout.BeginVertical("box");

        GUILayout.Label("Session Details", EditorStyles.boldLabel);

        GUILayout.Space(8);

        if (selectedSession == null)
        {
            GUILayout.FlexibleSpace();

            GUIStyle centered = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
            centered.fontSize = 13;

            GUILayout.Label(
                "Select a session from the left.",
                centered);

            GUILayout.FlexibleSpace();

            GUILayout.EndVertical();
            return;
        }

        GUIStyle big = new GUIStyle(EditorStyles.boldLabel);
        big.fontSize = 15;

        GUILayout.Label("📄 Selected Session", big);

        GUILayout.Space(10);

        EditorGUILayout.LabelField("🎬 Scene", selectedSession.SceneName);

        EditorGUILayout.LabelField(
            "⏱ Duration",
            $"{selectedSession.Metrics.Duration:F2} sec");

        EditorGUILayout.LabelField(
            "🚶 Distance",
            $"{selectedSession.Metrics.TotalDistance:F2} m");

        EditorGUILayout.LabelField(
            "⚡ Avg Speed",
            $"{selectedSession.Metrics.AverageSpeed:F2} m/s");

        EditorGUILayout.LabelField(
            "🎞 Frames",
            selectedSession.Metrics.FrameCount.ToString());

        EditorGUILayout.LabelField(
            "🎯 Events",
            selectedSession.Events.Count.ToString());

        GUILayout.Space(12);

        GUILayout.Label("Coming Soon", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox(
            "• Replay Viewer\n" +
            "• Timeline\n" +
            "• Heatmap\n" +
            "• CSV Export\n" +
            "• PDF Report",
            MessageType.None);

        GUILayout.FlexibleSpace();

        GUILayout.EndVertical();
    }
}