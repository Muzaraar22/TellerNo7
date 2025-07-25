using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for EventSystem

public class MoneyFlip : MonoBehaviour
{
    [SerializeField] private Sprite Image1;
    [SerializeField] private Sprite Image2;
    [SerializeField] private Button Money; // Button to trigger the flip animation
    private Image imageComponent;
    private Animator animator;

    void Awake()
    {
        imageComponent = GetComponent<Image>();
        animator = GetComponent<Animator>();
        imageComponent.sprite = Image1;
    }

    //dipanggil di pertengahan animasi (event trigger)
    void SwitchImage()
    {
        if (imageComponent.sprite == Image1)
        {
            imageComponent.sprite = Image2;
        }
        else
        {
            imageComponent.sprite = Image1;
        }
    }

    //dipanggil dari akhir animasi (event trigger)
    void NormalCondition()
    {
        animator.SetTrigger("Normal");
    }

    //dipanggil dari click button / money nya
    public void TriggerFlip()
    {
        animator.SetTrigger("Flip");
        EventSystem.current.SetSelectedGameObject(null);

    }


}
