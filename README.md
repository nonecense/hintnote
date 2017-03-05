# hintnote
Unity3D 5.5 UI Test

### やりたいこと
<pre>
ヒント的なキーワードを入力(保存)するだけで、インターネットから関連情報を引っ張ってきます。
※要するに、毎回検索ワードを入力する手間を省くだけのものです。

ある程度カテゴリを分けたら管理しやすいかなと思います。
カテゴリ毎に外部API(Google、Wikipedia、Weblio、etc)を指定できるようにしたいと思います。
</pre>

<img src="http://i.imgur.com/0ARI6my.png" alt="" title="">
### フォルダ構成
<pre>
Assets/
 App/
  Script/Config/                 ※設定ファイル
  Script/Controller/Scene名/     ※同Sceneでの複数画面
  Script/Entity/                 ※各GameObject毎のデータ
  Script/Module/Server/          ※APIサーバーとのやり取り関連(通信関連)
  Script/Module/Server/Utility/  ※各種Utility
  Script/Prefab/                 ※Assets/App/Resources/Prefabの制御Script
 Datas/                   ※キャッシュデータの保存
 Plugins/                 ※SimpleJson等Pluginの保管場所
</pre>

#### App/Script/Controller/
<pre>
１シーン毎にサブフォルダを用意、
UI関連(Homeシーン)は、１シーンで複数のパネルを入れ替えるようになっているので
Controllerのサブフォルダ下にPanel毎に{PanelName}Conroller.csが用意されてあります。
</pre>

