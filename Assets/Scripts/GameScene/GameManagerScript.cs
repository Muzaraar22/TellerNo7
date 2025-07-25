using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    [SerializeField] private GameObject computerScene;
    [SerializeField] private GameObject clientScene;
    [SerializeField] private GameObject optionButtons;


    public void DisplayComputerScene()
    {
        optionButtons.SetActive(false);
        computerScene.SetActive(true);
        clientScene.SetActive(false);
    }

    public void BackToClientScene()
    {
        optionButtons.SetActive(true);
        computerScene.SetActive(false);
        clientScene.SetActive(true);
    }
}
