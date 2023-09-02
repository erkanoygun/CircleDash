using UnityEngine.UI;
using UnityEngine;

public class NetWorkManager : MonoBehaviour
{
    [SerializeField] private Button _storeButton;
    private static string _policyUrl = "https://play.google.com/store/apps/developer?id=Erkan+Oygun&gl=TR";

    private void Start() {
        _storeButton.onClick.AddListener(StoreBtnOnClick);
    }

    private void StoreBtnOnClick()
    {
        Application.OpenURL(_policyUrl);
    }
}
