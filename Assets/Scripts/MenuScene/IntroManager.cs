using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject introPanel;
    public Text storyText;
    public GameObject buttonPanel;
    public GameObject settingsPanel;

    [Header("Buttons")]
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

    [Header("Audio")]
    public AudioSource typingSFX;
    public AudioClip[] typingClips;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private string[] dialogs = {
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

    private int currentIndex = 0;
    private string fullText = "";
    private bool isTyping = false;

    void Start()
    {
        introPanel.SetActive(false);
        settingsPanel.SetActive(false);
        buttonPanel.SetActive(true);

        startButton.onClick.AddListener(OnStartClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    void Update()
    {
        if (introPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                storyText.text = fullText;
                isTyping = false;
                typingSFX.Stop();
            }
            else if (currentIndex < dialogs.Length)
            {
                StartTyping(dialogs[currentIndex++]);
            }
            else
            {
                // Play fade animation via Animator, after selesai: Load next scene
                StartCoroutine(EndIntro());
            }
        }
    }

    void OnStartClicked()
    {
        introPanel.SetActive(true);
        buttonPanel.SetActive(false);
        // Stop BGM if needed
        StartTyping(dialogs[currentIndex++]);
    }

    void OnSettingsClicked()
    {
        settingsPanel.SetActive(true);
        // Optionally focus an input field
    }

    void OnQuitClicked()
    {
        Application.Quit();
    }

    void StartTyping(string text)
    {
        fullText = text;
        storyText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        foreach (char c in fullText)
        {
            storyText.text += c;

            if (!typingSFX.isPlaying)
            {
                typingSFX.clip = typingClips[Random.Range(0, typingClips.Length)];
                typingSFX.Play();
            }

            yield return new WaitForSeconds(typingSpeed);
        }
        typingSFX.Stop();
        isTyping = false;
    }

    IEnumerator EndIntro()
    {
        // Assuming Animator has fade animation and auto triggers
        Animator anim = introPanel.GetComponent<Animator>();
        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(2f); // durasi fade
        SceneManager.LoadScene("MainGame"); // pastikan sudah ditambahkan ke Build Settings
    }
}
