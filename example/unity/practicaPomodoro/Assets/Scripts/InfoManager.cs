using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField] public GameObject infoModal;
    
    public void showInfoModal()
    {
        infoModal.SetActive(true);
    }

    public void hideInfoModal()
    {
        infoModal.SetActive(false);
    }

    public void goToIG()
    {
        Application.OpenURL("https://www.instagram.com/pietrario_/");
    }
}
