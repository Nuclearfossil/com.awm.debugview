using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace awm.debugview.Editor
{
    class DebugViewSettings : ScriptableObject
    {
        public const string k_DebugViewSettingsPath = "Editor";
        public const string k_DebugViewSettingsFilename = "DebugViewSettings.asset";

        [SerializeField]
        private bool m_useRenderTexture;

        [SerializeField]
        private bool m_useAlpha;

        [SerializeField]
        private Color m_backgroundColor;

        [SerializeField]
        private Vector2 m_TextureSize;

        internal static DebugViewSettings GetOrCreateSettings()
        {
            var debugViewSettingsFilePath = Path.Combine("Assets", k_DebugViewSettingsPath, k_DebugViewSettingsFilename);
            var settings = AssetDatabase.LoadAssetAtPath<DebugViewSettings>(debugViewSettingsFilePath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<DebugViewSettings>();
                settings.m_useRenderTexture = false;
                settings.m_useAlpha = false;
                settings.m_TextureSize = new Vector2(200, 200);
                settings.m_backgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                AssetDatabase.CreateFolder("Assets", k_DebugViewSettingsPath);
                AssetDatabase.CreateAsset(settings, debugViewSettingsFilePath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
    }

    static class DebugViewSettingsIMGUIRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new SettingsProvider("Project/DebugViewIMGUISettings", SettingsScope.Project)
            {
                label = "Debug View Settings",
                guiHandler = (searchContext) =>
                {
                    var settings = DebugViewSettings.GetSerializedSettings();
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(settings.FindProperty("m_useRenderTexture"), new GUIContent("Use a Render Texture?"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_useAlpha"), new GUIContent("Use Alpha?"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_backgroundColor"), new GUIContent("Background Color:"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_TextureSize"), new GUIContent("Texture Size:"));
                    EditorGUI.indentLevel--;
                    settings.ApplyModifiedPropertiesWithoutUndo();
                },
                keywords = new HashSet<string>(new[] {"render", "texture", "Debug", "View", "Debug View"})
            };
            return provider;
        }
    }
}
