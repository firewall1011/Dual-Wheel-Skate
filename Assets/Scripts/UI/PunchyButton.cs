using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class PunchyButton : MonoBehaviour, ISelectHandler, IEventSystemHandler, ISubmitHandler
{
    [Header("On Submit Config")]
    [SerializeField] private Vector3 submitPunch = Vector3.one;
    [SerializeField] [Range(0.1f, 5f)] private float submitDuration = 1f;
    [SerializeField] private int submitVibrato = 10;
    [SerializeField] private float submitElasticity = 1f;
    
    [Header("On Select Config")]
    [SerializeField] private Vector3 selectPunch = Vector3.one;
    [SerializeField] [Range(0.1f, 5f)] private float selectDuration = 1f;
    [SerializeField] private int selectVibrato = 10;
    [SerializeField] private float selectElasticity = 1f;


    public void OnSelect(BaseEventData eventData)
    {
        transform.DOPunchScale(selectPunch, selectDuration, selectVibrato, selectElasticity);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        transform.DOPunchPosition(submitPunch, submitDuration, submitVibrato, submitElasticity);
    }
}
