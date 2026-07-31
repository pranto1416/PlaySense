using System;
using System.IO;
using UnityEngine;
using PlaySense.Data.Models;

namespace PlaySense.Export
{
    public static class SessionStorage
    {
        private static readonly string Folder =
            Path.Combine(Application.dataPath, "../PlaySenseSessions");

        public static void Save(SessionData session)
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            string filename =
                $"Session_{DateTime.Now:yyyyMMdd_HHmmss}.pss";

            string path = Path.Combine(Folder, filename);

            string json = JsonUtility.ToJson(session, true);

            File.WriteAllText(path, json);

            Debug.Log($"PlaySense Session Saved:\n{path}");
        }

        public static string[] GetSessionFiles()
        {
            if (!Directory.Exists(Folder))
                return Array.Empty<string>();

            return Directory.GetFiles(
                Folder,
                "*.pss",
                SearchOption.TopDirectoryOnly);
        }

        public static SessionData Load(string path){
            if(!File.Exists(path)){
                Debug.LogError($"Session not found:\n{path}");
                return null;
            }

            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SessionData>(json);
        }
    }
}