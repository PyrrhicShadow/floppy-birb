using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using UnityEngine.Localization.Settings; 

public class SplashManager : MonoBehaviour {

    [SerializeField] string sceneToLoad; 
    [SerializeField] Dropdown languages; 

    [Header("Background graphics")]
    [SerializeField] GameObject player; 
    private float playerTimer; 
    [SerializeField] float playerVelocity; 
    [SerializeField] float playerDelay; 
    [SerializeField] PipeSpawner pipeSpawner; 
    [SerializeField] GameObject cloudSpawner; 

    // Start is called before the first frame update
    void Start() {
        languages.onValueChanged.AddListener(LocaleSelected); 
        pipeSpawner.Begin(); 
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ClickToStart() {
        SceneManager.LoadScene(sceneToLoad); 
    }

    static void LocaleSelected(int index) {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index]; 
        PlayerPrefs.SetInt("Locale", index); 
    }

    public void LanguageDropDown(int value) {
        PlayerPrefs.SetInt("Locale", value);
        ChangeLanguage(); 
    } 

    private void ChangeLanguage() {
        // This variable selects the language. For example, the first language in the table is English, so 0 = English. 
        int i = PlayerPrefs.GetInt("Locale", 0); 

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }
}
