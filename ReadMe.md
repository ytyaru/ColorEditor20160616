# このソフトウェアについて #

ColorEditor20160616は私個人が学習目的で作成したソフトウェアです。

[色編集アプリ](https://github.com/ytyaru/ColorEditor20160615)を改修しました。
色を表示する面積を増やしました。

# 開発環境 #

* Windows XP SP3
* .NET Framework 4.0
* Windows Form Application
* C#
* Visual C# 2010 Express

# イメージ #

![色を表示する面積を増やした](http://cdn-ak.f.st-hatena.com/images/fotolife/y/ytyaru/20160618/20160618115346.png)

# 改修内容 #

## 2016/06/18 13:50 ##

以下のissueに対応しました。

* [#1 TrackBarの表示がちらつく](https://github.com/ytyaru/ColorEditor20160616/issues/1)
* [#2 コントロールごとに色の反映に時差がある](https://github.com/ytyaru/ColorEditor20160616/issues/2)
* [#3 NumericUpDownの上下ボタンの下部に前の色が残る](https://github.com/ytyaru/ColorEditor20160616/issues/3)

他、以下も行いました。

* PictureBoxの使用をやめた

## 2016/06/17 13:05 ##

* ウインドウサイズを大きくすると隙間が開いてしまう
    * Anchorプロパティで自動調整するようにした
* ウインドウサイズを小さくしすぎるとUI操作ができなくなってしまう
    * ウインドウの高さの最小値を128にした

他、以下も行いました。

* TrackBar
    * 目盛り非表示にした（TickStyle=None）
* NumericUpDown
    * Fontを変更した（Size=12, Style=Bold）
    * 枠を外した（BorderStyle=None）
* Panel
    * 座標を微調整した

# ライセンス #

このソフトウェアはCC0ライセンスです。

[![CC0](http://i.creativecommons.org/p/zero/1.0/88x31.png "CC0")](http://creativecommons.org/publicdomain/zero/1.0/deed.ja)
