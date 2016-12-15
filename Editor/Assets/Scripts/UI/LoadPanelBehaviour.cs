using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanelBehaviour : UIBehaviour
{
    public GameObject m_rowTemplate;

    private string m_targetFolder;
    private Button m_openFolderButton;
    private Button m_loadButton;
    private Button m_cancelButton;
    private string m_savePath;
    private RectTransform m_contentList;
    private SelectableRow m_selectedRow;

    private List<SelectableRow> m_rows = new List<SelectableRow>();

    public void Show(string folder)
    {
        base.Show();
        m_targetFolder = folder;
        UpdateListing();
    }
	
	public override void Hide()
	{
		base.Hide();
		if(m_selectedRow != null)
		{
			m_selectedRow.Deselect();
		}
	}

    protected override void Start()
    {
        m_loadButton = Find("Load").GetComponent<Button>();
        m_cancelButton = Find("Cancel").GetComponent<Button>();
        m_openFolderButton = Find("Open").GetComponent<Button>();
        m_contentList = FindNested("Content List").GetComponent<RectTransform>();

        m_loadButton.onClick.AddListener(OnLoad);
        m_cancelButton.onClick.AddListener(OnCancel);
        m_openFolderButton.onClick.AddListener(OnOpen);

        m_loadButton.interactable = false;
        gameObject.SetActive(false);
    }

    void OnOpen()
    {
        System.Diagnostics.Process.Start(Path.GetFullPath(m_targetFolder));
    }

    void OnCancel()
    {
        gameObject.SetActive(false);
    }

    void OnLoad()
    {
        if(m_selectedRow != null)
        {
            string trimmed = m_selectedRow.GetText().Trim().ToLower();
            m_savePath = m_targetFolder + "/" + trimmed + PathManager.instance.m_packageExtension;
            if(File.Exists(m_savePath))
            {
                // DO LOADING HERE
                Hide();
            }
            else
            {
                // Show popup?
                UIManager.instance.ShowModal("Load", "The requested file does not exist.", new string[] { "Ok" }, null);
            }
        }
    }

    void OnRowSelected(SelectableRow newRow)
    {
        if(m_selectedRow != null)
            m_selectedRow.Deselect();

        m_loadButton.interactable = true;
        m_selectedRow = newRow;
    }

    void UpdateListing()
    {
        m_selectedRow = null;
        m_loadButton.interactable = false;
        foreach(var go in m_rows)
        {
            go.gameObject.SetActive(false);
        }

        var files = Directory.GetFiles(m_targetFolder, "*" + PathManager.instance.m_packageExtension);
        m_contentList.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, files.Length * 30);
        for(int i = 0; i < files.Length; i++)
        {
            if(m_rows.Count == i)
            {
                var row = Instantiate(m_rowTemplate).GetComponent<SelectableRow>();
                row.transform.SetParent(m_contentList);
                row.eventClicked += OnRowSelected;
                m_rows.Add(row);
            }
            m_rows[i].gameObject.SetActive(true);
            m_rows[i].SetText(Path.GetFileNameWithoutExtension(files[i]));
        }
    }
}
