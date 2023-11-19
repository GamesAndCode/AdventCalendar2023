using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class DoorContentUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button downloadButton;
    [SerializeField] private Button copyButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TMP_Text passwordUI;
    [SerializeField] private LeanTweenType easeInType = LeanTweenType.easeInOutExpo;
    [SerializeField] private LeanTweenType easeOutType = LeanTweenType.easeOutBack;
    [Header("Content")]
    [SerializeField] private string downloadLink;
    [SerializeField] private string password;
    [Header("Audio")]
    [SerializeField] private AudioClip pointerClose;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        closeButton.onClick.AddListener(() => CloseContentWindow());

        if (downloadLink != null || downloadLink.Trim() != "")
        {
            downloadButton.onClick.AddListener(() => Application.OpenURL(downloadLink));
            copyButton.onClick.AddListener(() => GUIUtility.systemCopyBuffer = password);
            passwordUI.text = password;
        }
    }

    public void Show()
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.SetActive(true);
        gameObject.LeanScale(Vector3.one, 0.5f).setEase(easeInType);
    }

    public void CloseContentWindow()
    {
        audioSource.PlayOneShot(pointerClose);
        gameObject.LeanScale(Vector2.zero, 0.5f).setEase(easeOutType).setOnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
