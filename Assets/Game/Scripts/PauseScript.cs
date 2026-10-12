using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private Sprite checkedSprite;
    [SerializeField] private Sprite uncheckedSprite;
    [SerializeField] private GameObject[] turnOffObjects;
    private bool _isStopped;
    private Button _button;
    private Image _image;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _button.onClick.AddListener(OnClickEvent);
    }

    private void OnClickEvent()
    {
        if (_isStopped)
        {
            _isStopped = false;
            _image.sprite = uncheckedSprite;
            Time.timeScale = 1;
            foreach (GameObject turnOffObject in turnOffObjects)
            {
                turnOffObject.SetActive(true);
            }
        }
        else
        {
            _isStopped = true;
            _image.sprite = checkedSprite;
            Time.timeScale = 0;
            foreach (GameObject turnOffObject in turnOffObjects)
            {
                turnOffObject.SetActive(false);
            }
        }
    }
}
