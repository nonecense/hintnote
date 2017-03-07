using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Presto.Module.Utility;

namespace Presto.Controller.Home {
    public class WebViewController : BaseController {
        public Text Text;

        public void RefreshPanel(string html)
        {
            this.Text.text = html;
        }
    }
}