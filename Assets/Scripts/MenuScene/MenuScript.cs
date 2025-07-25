using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MenuScript : MonoBehaviour
{
    public InputActionAsset inputActions;
    //untuk invoke ke typesfx
    public UnityEvent stopTypingSFX;
    public UnityEvent playTypingSFX;
    [Header("UI References")]
    public GameObject introPanelCanvas;
    public Text storyText;
    private InputAction m_continueAction;
    private int current_index = 0;
    private string full_text = "";
    private Coroutine typingCoroutine;
    private bool is_typing = false;

    [Header("Typing Settings")]
    [field: Range(0.01f, 0.1f)]
    public float typing_speed = 0.03f;

    public void OnStartClicked()
    {
        introPanelCanvas.SetActive(true);
        inputActions.FindActionMap("Menu").Enable();
        StartCoroutine(PauseToPlayIntro());
        m_continueAction = InputSystem.actions.FindAction("NextStory");
    }

    IEnumerator PauseToPlayIntro()
    {
        yield return new WaitForSeconds(0.5f);
        StartIntro();
    }

    public void Update()
    {
        //IsPressed(), WasReleasedThisFrame(), WasPressedThisFrame() pilihan
        if (m_continueAction != null && m_continueAction.WasPressedThisFrame() && introPanelCanvas.activeSelf)
        {
            if (!is_typing)
            {
                if (current_index < dialogs.Length)
                {
                    current_index++;
                    StartTyping(dialogs[current_index]);
                }
                else
                {
                    introPanelCanvas.SetActive(false);
                    // SceneManager.LoadScene("GameScene");
                }
            }
            else
            {
                stopTypingSFX?.Invoke();
                is_typing = false;
                storyText.text = full_text;
            }
        }
    }

    private readonly string[] dialogs = {
        "Good Morning.",
        "Today is your first day here.",
        "I can’t show up at work today so I’ll show you the rope through the phone.",
        "First, if a client arrives, they will state their business and you will check their money.",
        "You need to check the money manually by hand cuz we’re kinda broke anyway.",
        "You can see the authentic money design on your computer.",
        "Do check it several times if you’re not sure.",
        "Each client will show you a maximum of 5 money.",
        "Why? Because we trust our client with only those five cash.",
        "Huh… maybe that explains why we're broke.",
        "But anyway, watch out.",
        "There’s criminals everywhere and you can report them with that red button under your desk.",
        "You must not make our company more broke.",
        "Ask the client about the fake money.",
        "Maybe they will change it, maybe they will not.",
        "I don't know.",
        "You be the judge.",
        "That's it I guess.",
        "Good luck surviving for 3 days!"
    };



    //dipanggil dari event animation PanelIn selesai
    //eh tapi ga bisa ding, karena event animation hanya bisa dipanggil dari script object yang dianimasiin (panel itu sendiri)
    //sedangkan ini script berada di canvasMenu
    protected void StartIntro()
    {
        current_index = 0;
        StartTyping(dialogs[current_index]);
        current_index++;
    }

    protected void StartTyping(string text)
    {
        // Hentikan coroutine yang kemungkinan masih jalan
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        full_text = text;
        is_typing = true;
        storyText.text = "";
        
        typingCoroutine = StartCoroutine(TypeText(full_text));
    }

    private IEnumerator TypeText(string textToType)
    {
        playTypingSFX?.Invoke();
        foreach (char c in textToType)
        {
            if (!is_typing)
            {
                yield break;
            }

            storyText.text += c;
            yield return new WaitForSeconds(typing_speed);
        }
        is_typing = false;
        stopTypingSFX?.Invoke();
        //stop typing sound effect
    }
    // protected void StartTyping(string text)
    // {
    //     full_text = text;
    //     is_typing = true;
    //     storyText.text = "";
    //     TypeNextChar(0);
    // }

    // private void TypeNextChar(int index)
    // {
    //     if (!is_typing)
    //         break;

    //     if (index < full_text.Length)
    //     {
    //         storyText.text += full_text[index];
    //         StartCoroutine(TypePause());
    //         TypeNextChar(index + 1);
    //     }
    //     else
    //     {
    //         is_typing = false;
    //         //stop typing sound effect
    //     }
    // }

    // private IEnumerator TypePause()
    // {
    //     playTypingSFX?.Invoke();
    //     yield return new WaitForSeconds(typing_speed);
    // }


    /*func start_intro():
	current_index = 0
	intro_panel.visible = true
	intro_panel.modulate.a = 1.0
	start_typing(dialogs[current_index])
	current_index += 1
	
func start_typing(text: String):
	full_text = text
	is_typing = true
	story.text = ""
	_type_next_char(0)
	
func _type_next_char(index: int):
	if not is_typing:
		return
	if index < full_text.length():
		story.text += full_text[index]
		000
			typing_sfx.stream = typing_sounds[randi() % typing_sounds.size()]
			typing_sfx.play()
		await get_tree().create_timer(typing_speed).timeout
		_type_next_char(index + 1)
	else:
		is_typing = false
		typing_sfx.stop()

    func _input(event):
	if not intro_panel.visible:
		return

	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT and event.pressed:
		if is_typing:
			typing_sfx.stop()
			is_typing = false
			story.text = full_text
		elif current_index < dialogs.size():
			start_typing(dialogs[current_index])
			current_index += 1
		else:
			intro_animation.play("fade")
    */

}
