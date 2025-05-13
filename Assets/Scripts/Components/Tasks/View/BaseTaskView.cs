using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseTaskView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    public TMP_Text Text => _text;
    public Image Image => _image;

    public void SetStatus(TaskStatus status)
    {
        switch (status)
        {
            case TaskStatus.InProgress:_image.color = Color.yellow;  break;
            case TaskStatus.Completed:_image.color = Color.green;  break;
            default:_image.color = Color.red; break;
        }
    }
  
}
