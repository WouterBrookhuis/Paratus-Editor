using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathManager : Singleton<PathManager>
{
	public string m_relativeEnvironmentPath = "Environments";
    public string m_relativeScenarioPath = "Scenarios";
    public string m_relativeTexturePath = "Textures";
    public string m_packageExtension = ".pak";
    public string[] m_textureExtensions = new string[] { ".jpg", ".png" };

    public bool m_usePersistentDataPath = true;

	
	public string EnvironmentPath
	{
		get
		{
			return BasePath + "/" + m_relativeEnvironmentPath; 
		}
	}
	
    public string ScenarioPath
    {
        get
        {
            return BasePath + "/" + m_relativeScenarioPath;
        }
    }

    public string TexturePath
    {
        get
        {
            return BasePath + "/" + m_relativeTexturePath;
        }
    }

    public string BasePath
    {
        get
        {
            if(m_usePersistentDataPath)
            {
                return Application.persistentDataPath;
            }
            else
            {
                return Application.dataPath;
            }
        }
    }

    void Awake()
    {
        if(!Directory.Exists(ScenarioPath))
        {
            Directory.CreateDirectory(ScenarioPath);
        }
        if(!Directory.Exists(TexturePath))
        {
            Directory.CreateDirectory(TexturePath);
        }
		if(!Directory.Exists(EnvironmentPath))
        {
            Directory.CreateDirectory(EnvironmentPath);
        }
    }
}
