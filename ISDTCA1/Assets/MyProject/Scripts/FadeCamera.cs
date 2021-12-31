using UnityEngine;

public class FadeCamera : MonoBehaviour
{
    #region Variables
    //Private Variables

    [SerializeField] private RectTransform _fadeScreenRectTransform;

    [Header("Fade Settings")]
    [SerializeField] [Range(0.1f, 3.0f)] private float _fadeInTime = 1.0f;
    [SerializeField] [Range(0.1f, 3.0f)] private float _fadeOutTime = 1.0f;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    protected void Start()
    {
        var seq = LeanTween.sequence();
        seq.append(6f);
        seq.append( () => {
            FadeOutCam();
        });
        seq.append(5f);
        seq.append( () => {
            FadeInCam();
        });
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Own Methods

    public void FadeInCam(){
        LeanTween.alpha(_fadeScreenRectTransform, 0f, _fadeInTime);
    }

    public void FadeOutCam(){
        LeanTween.alpha(_fadeScreenRectTransform, 0f, _fadeOutTime);
    }
    #endregion
}
