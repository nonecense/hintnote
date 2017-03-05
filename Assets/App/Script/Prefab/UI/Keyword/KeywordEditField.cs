using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.Controller.Home;

namespace Presto.UI
{
    public class KeywordEditField : Presto.UI.UIBase
    {
        public InputField InputFieldTitle;
        public int id = 1;
        public JSONNode Data;

        public void SetData(JSONNode _data)
        {
            this.Data = _data;
            this.id = this.Data["id"].AsInt;
            this.InputFieldTitle.text = this.Data["title"];
        }

    }
}
