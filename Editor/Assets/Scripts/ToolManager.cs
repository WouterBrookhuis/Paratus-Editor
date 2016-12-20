using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : Singleton<ToolManager>
{
    [Flags]
    public enum EditorMode
    {
        None        = 0,
        Environment = 1,
        Scenario    = 2,
        Importer    = 4,
        All = ~None
    }

    public ToolController m_controller;
    public EditorMode m_mode;

	void Awake()
    {
        if(m_controller == null)
        {
            m_controller = ToolController.instance;
        }
    }

    void Start()
    {
        SwitchMode(EditorMode.Environment);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab))
        {
            EditorMode mode = (EditorMode)((int)m_mode << 1);
            if(mode > EditorMode.Importer)
            {
                mode = EditorMode.Environment;
            }
            SwitchMode(mode);
        }
	}
    
    public void SwitchMode(EditorMode mode)
    {
        Debug.Log("Switching to editor mode " + mode.ToString());
        m_mode = mode;
        m_controller.ChangeEditorMode(m_mode);
    }
}
