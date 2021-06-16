using UnityEditor;

namespace awm.debugview.Editor
{
    ///-----------------------------------------------------------------------
    /// <remarks>
    /// <copyright file="DebugViewEditor.cs" company="Unity Technologies">
    /// The MIT License (MIT)
    /// 
    /// Copyright (c) 2019-2020 Omiya Games
    /// 
    /// Permission is hereby granted, free of charge, to any person obtaining a copy
    /// of this software and associated documentation files (the "Software"), to deal
    /// in the Software without restriction, including without limitation the rights
    /// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    /// copies of the Software, and to permit persons to whom the Software is
    /// furnished to do so, subject to the following conditions:
    /// 
    /// The above copyright notice and this permission notice shall be included in
    /// all copies or substantial portions of the Software.
    /// 
    /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    /// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    /// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    /// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    /// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    /// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    /// THE SOFTWARE.
    /// </copyright>
    /// <list type="table">
    /// <listheader>
    /// <term>Revision</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>
    /// <strong>Version:</strong> 1.0.0<br/>
    /// <strong>Date:</strong> 06/15/21<br/>
    /// <strong>Author:</strong> Ash Matheson
    /// </term>
    /// <description>Initial verison.</description>
    /// </item>
    /// </list>
    /// </remarks>
    ///-----------------------------------------------------------------------
    /// <summary>
    /// This is an example script for starting an editor inspector.
    /// </summary>
    /// <seealso cref="RuntimeExample"/>
    [CustomEditor(typeof(awm.debugview.Player.DebugView))]
    public class DebugViewEditor : UnityEditor.Editor
    {
        /// <summary>
        /// 
        /// </summary>
        SerializedProperty useRenderTexture;
        SerializedProperty renderTexture;

        /// <summary>
        /// OnEnable is called on the frame when a script is displayed in the
        /// inspector just before OnInspectorGUI is called the first time.
        /// </summary>
        public void OnEnable()
        {
            useRenderTexture = serializedObject.FindProperty("useRenderTexture");
            renderTexture = serializedObject.FindProperty("renderTexture");
        }

        /// <summary>
        /// OnInspectorGUI is called every frame, if this script is displayed
        /// in the inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(useRenderTexture, true);
            EditorGUILayout.PropertyField(renderTexture, true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
