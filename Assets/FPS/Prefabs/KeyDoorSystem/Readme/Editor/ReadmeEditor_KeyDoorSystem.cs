using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection; 

[CustomEditor(typeof(Readme_KeyDoorSystem))]
[InitializeOnLoad]
public class ReadmeEditor_KeyDoorSystem : Editor {
	
	static float kSpace = 16f;
	
	protected override void OnHeaderGUI()
	{
		var readme = (Readme_KeyDoorSystem)target;
		Init();
		
		GUILayout.BeginHorizontal("In BigTitle");

        float headerAspectRatio = (float)readme.codeMonkeyHeader.height / readme.codeMonkeyHeader.width;
        float width = EditorGUIUtility.currentViewWidth - 30f;
        GUILayout.Label(readme.codeMonkeyHeader, GUILayout.Width(width), GUILayout.Height(width * headerAspectRatio));

		GUILayout.EndHorizontal();
        
        GUILayout.Label(readme.title, HeaderStyle);
	}
	
	public override void OnInspectorGUI()
	{
		var readme = (Readme_KeyDoorSystem)target;
		Init();
		
		foreach (var section in readme.sections)
		{
			if (!string.IsNullOrEmpty(section.heading))
			{
				GUILayout.Label(section.heading, HeadingStyle);
			}
            if (section.textLines != null) 
            {
                foreach (var textLine in section.textLines) 
                {
                    if (!string.IsNullOrEmpty(textLine)) 
                    {
                        string sectionText = textLine;
                        sectionText = sectionText.Replace("\\n", "\n");
                        GUILayout.Label(sectionText, BodyStyleSmall);
                    }
                }
            }
			if (!string.IsNullOrEmpty(section.linkText))
			{
				GUILayout.Space(kSpace / 2);
				if (LinkLabel(new GUIContent(section.linkText)))
				{
					Application.OpenURL(section.url);
				}
			}
			GUILayout.Space(kSpace);
		}
	}
	
	
	bool m_Initialized;
	
	GUIStyle LinkStyle { get { return m_LinkStyle; } }
	[SerializeField] GUIStyle m_LinkStyle;
	
	GUIStyle HeaderStyle { get { return m_HeaderStyle; } }
	[SerializeField] GUIStyle m_HeaderStyle;
	
	GUIStyle TitleStyle { get { return m_TitleStyle; } }
	[SerializeField] GUIStyle m_TitleStyle;
	
	GUIStyle HeadingStyle { get { return m_HeadingStyle; } }
	[SerializeField] GUIStyle m_HeadingStyle;
	
	GUIStyle BodyStyle { get { return m_BodyStyle; } }
	[SerializeField] GUIStyle m_BodyStyle;
	
	GUIStyle BodyStyleSmall { get { return m_BodyStyleSmall; } }
	[SerializeField] GUIStyle m_BodyStyleSmall;
	
	void Init()
	{
		if (m_Initialized)
			return;
		m_BodyStyle = new GUIStyle(EditorStyles.label);
		m_BodyStyle.wordWrap = true;
		m_BodyStyle.fontSize = 14;
        m_BodyStyle.richText = true;
		
		m_BodyStyleSmall = new GUIStyle(m_BodyStyle);
		m_BodyStyleSmall.fontSize = 12;

		m_TitleStyle = new GUIStyle(m_BodyStyle);
		m_TitleStyle.fontSize = 24;
        
		m_HeaderStyle = new GUIStyle(m_BodyStyle);
		m_HeaderStyle.fontSize = 24;
		m_HeaderStyle.fontStyle = FontStyle.Bold;
        m_HeaderStyle.alignment = TextAnchor.MiddleCenter;

        m_HeadingStyle = new GUIStyle(m_BodyStyle);
		m_HeadingStyle.fontSize = 18;
		m_HeadingStyle.fontStyle = FontStyle.Bold; 
		
		m_LinkStyle = new GUIStyle(m_BodyStyle);
		// Match selection color which works nicely for both light and dark skins
		m_LinkStyle.normal.textColor = new Color (0x00/255f, 0x78/255f, 0xDA/255f, 1f);
		m_LinkStyle.stretchWidth = false;
		
		m_Initialized = true;
	}
	
	bool LinkLabel (GUIContent label, params GUILayoutOption[] options)
	{
		var position = GUILayoutUtility.GetRect(label, LinkStyle, options);

		Handles.BeginGUI ();
		Handles.color = LinkStyle.normal.textColor;
		Handles.DrawLine (new Vector3(position.xMin, position.yMax), new Vector3(position.xMax, position.yMax));
		Handles.color = Color.white;
		Handles.EndGUI ();

		EditorGUIUtility.AddCursorRect (position, MouseCursor.Link);

		return GUI.Button (position, label, LinkStyle);
	}

}

