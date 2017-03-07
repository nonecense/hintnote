# hintnote
Unity3D 5.5 UI Sample
<img src="http://i.imgur.com/0ARI6my.png" alt="" title=""><br>
<img src="http://i.imgur.com/L2vo5MY.png" alt="" title="">

### やりたいこと
<pre>
ヒント的なキーワードを入力(保存)するだけで、インターネットから関連情報を引っ張ってきます。
※要するに、毎回検索ワードを入力する手間を省くだけのものです。

ある程度カテゴリを分けたら管理しやすいかなと思います。
カテゴリ毎に外部API(Google、Wikipedia、Weblio、etc)を指定できるようにしたいと思います。

</pre>

### TODO
<pre>
運営が提供するマスターキーワードとユーザが登録変更したキーワードの共存方法
</pre>

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

##### App/Script/Controller/
<pre>
１シーン毎にサブフォルダを用意し、１シーンで複数のパネルをカメラ視角へ切替することで画面の切替をおこなっています。
Controllerのサブフォルダ配下には、パネル毎に{PanelName}Conroller.csを用意しています。
</pre>

### キャッシュファイルについて
<pre>
- SimpleJson形式でキャッシュしています。
- カテゴリは全部10階層までサブフォルダを作成することが可能です。
例）
- Assets/App/Datas/Cache/hintnote/master/categories/category.txt
  トップページに表示するカテゴリ一覧
- Assets/App/Datas/Cache/hintnote/master/categories/2/category.txt
  トップページの２番目をクリックした際表示するカテゴリ一覧
</pre>
