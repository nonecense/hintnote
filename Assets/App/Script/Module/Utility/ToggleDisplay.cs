using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presto.Module.Utility
{
    public class ToggleDisplay : MonoBehaviour
    {
        public bool DisplayFlg = true;

        void Awake()
        {
            gameObject.SetActive(gameObject.GetComponent<ToggleDisplay>().DisplayFlg);
        }

        public void Show(Toggle t=null)
        {
            gameObject.SetActive(true);
        }

        public void Hide(Toggle t = null)
        {
            gameObject.SetActive(false);
        }

        public void Handle(Toggle t = null)
        {
            gameObject.GetComponent<ToggleDisplay>().DisplayFlg = !gameObject.GetComponent<ToggleDisplay>().DisplayFlg;
            gameObject.SetActive(gameObject.GetComponent<ToggleDisplay>().DisplayFlg);
        }
    }

}
