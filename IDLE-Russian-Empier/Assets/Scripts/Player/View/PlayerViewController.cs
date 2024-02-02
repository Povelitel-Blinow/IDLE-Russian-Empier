using UnityEngine;

namespace UICapsule
{
    public class PlayerViewController : MonoBehaviour
    {
        public static PlayerViewController Instance { get; private set; }

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public void ShowBuildingInfo(ShowUIPanelRequest panelRequest)
        {

        }
    }

    public struct ShowUIPanelRequest
    {
        public string Name { get; private set; }
        public string Info { get; private set; }

        public ShowUIPanelRequest(string name, string info)
        {
            Name = name;
            Info = info;
        }
    }
}