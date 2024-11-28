using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    private GameObject content;

    void Start()
    {
        content = transform.Find("Content").gameObject;
        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive(!content.activeInHierarchy);
        }
    }

    public void OnSoundEffectsChanged(System.Single value)
    {
        GameState.effectsVolume = value;
    }
}
