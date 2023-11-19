using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image)), RequireComponent(typeof(AudioSource))]
public class UIImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip pointerEnter;
    [SerializeField] private AudioClip pointerExit;
    [SerializeField] private AudioClip pointerClick;

    private AudioSource audioSource;
    private DoorContentUI doorContentUI;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(pointerEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.PlayOneShot(pointerExit);
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        doorContentUI.Show();
        audioSource.PlayOneShot(pointerClick);
    }

    public void SetDoorContentUI(DoorContentUI doorContentUI)
    {
        this.doorContentUI = doorContentUI;
    }
}
