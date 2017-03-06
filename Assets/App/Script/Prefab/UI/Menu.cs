using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.Controller.Home;

namespace Presto.UI
{
    public class Menu : Presto.UI.UIBase
    {
        public int id = 0;
        public Text TextTitle;
        public Text TextTitleIcon;
        public JSONNode MenuData;

        public void SetData(JSONNode json_node)
        {
            this.MenuData = json_node;
            this.id = this.MenuData["sno"].AsInt;
            this.TextTitle.text = this.MenuData["title"].ToString().Trim('"');  // TODO なんかダブルクォーテーションがついているので削除

            switch (this.MenuData["type"])
            {
                case "1": // folder
                    this.TextTitleIcon.text = "";
                    break;
                case "2": // favorite
                    this.TextTitleIcon.text = "";  //
                    this.TextTitle.color = new Color(1, 1, 1, 1);   // FFFFFFFF
                    this.TextTitleIcon.color =  new Color(106f / 255f, 161f / 255f, 68f / 255f, 255f / 255f);
                    gameObject.GetComponent<Image>().color = new Color(86f / 255f, 143f / 255f, 47f / 255f, 255f / 255f); //"568E2FFF";
                    break;
                case "3": // keyword
                default:
                    this.TextTitleIcon.text = "";
                    break;
            }
        }


        // TODO
        public void OnClickAction()
        {
            if (this.MenuData["keyword"].Count > 0)
            {
                // キーワード一覧の表示
                BaseController.GetPanelWithTag("PanelKeywordList").GetComponent<KeywordListController>().RefreshKeywords(this.MenuData["keyword"]);
                BaseController.GetPanelWithTag("PanelKeywordList").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            }
            else if(this.MenuData.Count > 0)
            {
                // サブメニューの表示
                BaseController.GetPanelWithTag("PanelHome").GetComponent<HomeController>().RefreshPanel(Presto.Module.Utility.Cache.LoadSubCategory(this.MenuData));
            }
        }

    }
}
