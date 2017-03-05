using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SimpleJSON;
using Presto.Controller.Home;
using Presto.Module.Utility;

namespace Presto.UI
{
    public class CategoryEditField : Presto.UI.UIBase
    {
        public int id = 1;
        public JSONNode Data;
        public InputField InputfieldTitle;
        public Image SaveButton;
        public Image DeleteButton;


        public void SetData(JSONNode json_node)
        {
            this.Data = json_node;
            this.id = this.Data["id"].AsInt;
            this.InputfieldTitle.text = this.Data["title"];
        }


        public void ShowSaveButton()
        {
            if ( ! Presto.Module.Utility.String.Equal(this.InputfieldTitle.text, this.Data["title"]))
            {
                this.SaveButton.GetComponent<ToggleDisplay>().Show(this.SaveButton.GetComponent<Toggle>());
            }else
            {
                this.SaveButton.GetComponent<ToggleDisplay>().Hide(this.SaveButton.GetComponent<Toggle>());
            }
        }


        public void ClickSaveButton()
        {
            string msg = "下記カテゴリを保存しますか？\n\n" + this.InputfieldTitle.text;
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<Presto.Module.Utility.TogglePanelPosition>().Handle();
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<ConfirmController>().SetAction(ConfirmController.OK_ACTION_CATEGORY_SAVE, msg);
        }

        public void ClickDeleteButton()
        {
            string msg = "下記カテゴリを削除しますか？\n\n" + this.InputfieldTitle.text;
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<Presto.Module.Utility.TogglePanelPosition>().Handle();
            BaseController.GetPanelWithTag("PanelConfirm").GetComponent<ConfirmController>().SetAction(ConfirmController.OK_ACTION_CATEGORY_DELETE, msg);
        }
    }
}
