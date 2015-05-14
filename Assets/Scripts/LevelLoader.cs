using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private enum LoadOn
    {
        None,
        Awake,
        Start,
    }
  
    void Awake()
    {
        if (_load == LoadOn.Awake)
        {
            print("loading levels");
            LoadLevels();
        }
    }

    void Start()
    {
        if (_load == LoadOn.Start)
            LoadLevels();
    }

    [ContextMenu("Load Levels")]
    void LoadLevels()
    { 
            foreach (string s in _levels)
                Application.LoadLevelAdditive(s);
    }

    [SerializeField]
    private LoadOn _load;
    [SerializeField]
    private string[] _levels;
    
    
}
