using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI invisibleTime;
        public TextMeshProUGUI currentCountText;
        public TextMeshProUGUI resultCountText;
        public GameObject replayPanel;

        private void Awake()
        {
            replayPanel.SetActive(false);
        }

        public void ShowReplayPanel(int res)
        {
            resultCountText.text = "Ваши очки " + res;
            replayPanel.SetActive(true);
        }

        public void UpdateText(int res)
        {
            currentCountText.text = res.ToString();
        }
        
        public void UpdateInvisibleText(int res)
        {
            invisibleTime.text = res.ToString();
        }
    }
}