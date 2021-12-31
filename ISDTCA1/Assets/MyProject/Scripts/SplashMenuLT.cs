using UnityEngine;

public class SplashMenuLT : MonoBehaviour
{
    #region Variables
    //Private Variables

    private AudioSource[] allAudioSources;
    public GameObject Logo;
    [SerializeField] private GameObject _splashScr;

    [Header("SplashScreen Settings")]

    [Header("Decal on Floor")]
    [SerializeField] private GameObject _decalJetHammer;
    [SerializeField] private CanvasGroup _mainMenuPanel;
    private RectTransform _splashScrRectTransform;

    #endregion

    #region Unity Methods

    protected void Awake()
    {
        _splashScr.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
        _splashScrRectTransform = _splashScr.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        var seq = LeanTween.sequence();
        seq.append(2f);
        seq.append( () => {
            FadeInLogo();
        });
        seq.append(3f);
        seq.append( () => {
            FadeOutLogo();
        });
        seq.append(1f);
        seq.append( () => {
            Logo.SetActive(false);
            ShowDecalAndMenu();
            PlayAllAudio();
        }); 
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Own Methods

    private void FadeInLogo()
    {
        LeanTween.scaleX(_splashScr, 1.2f, 1f);
        LeanTween.scaleY(_splashScr, 1.2f, 1f);
        LeanTween.alpha(_splashScrRectTransform, 1f, 1f);
    }

    private void FadeOutLogo()
    {
        LeanTween.scaleX(_splashScr, 0.8f, 1f);
        LeanTween.scaleY(_splashScr, 0.8f, 1f);
        LeanTween.alpha(_splashScrRectTransform, 0f, 1f);
    }

    private void ShowDecalAndMenu()
    {
        _decalJetHammer.SetActive(true);
        LeanTween.alphaCanvas(_mainMenuPanel, 1f, 1f);
    }

    void PlayAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Play();
        }
    }
    #endregion
}
