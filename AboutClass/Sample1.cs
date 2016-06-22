﻿using System.Windows.Forms;
using System.Drawing;
using System;

class Sample1 {
	public static void Main() {

		//フォームの作成
		Form form = new Form();
		form.Text = "サンプル";
		form.Width = 600;
		form.Height = 300;

		//要素数3の配列を作成
		PictureBox[] pictureBox = new PictureBox[3];
			for (int i = 0; i < pictureBox.Length; i++) {
				//要素数分のピクチャボックスの作成
				pictureBox[i] = new PictureBox();
				pictureBox[i].Parent = form;
			}

		//要素数3の配列を作成
		Car[] car = new Car[3];
		car[0] = new RacingCar1();
		car[1] = new RacingCar2();
		car[1].Top = 75;
		car[2] = new RacingCar3();
		car[2].Top = 150;
			for (int i = 0; i < car.Length; i++) {
				//メソッドを呼び出して値を取得
				pictureBox[i].Image = car[i].GetImage();
				pictureBox[i].Top = car[i].Top;
				pictureBox[i].Left = car[i].Left;
			}

		//ボタンの作成
		Button button = new Button();
		button.Size = new Size(100, 30);
		button.Text = "移動";
		button.Location = new Point(10, form.Height - 80);
		button.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		button.Parent = form;
		//押したときの処理
		button.Click += delegate (object sender, EventArgs e) {
			for(int i = 0; i < car.Length; i++) {
				car[i].Move();
				pictureBox[i].Left = car[i].Left;
			}
		};

		//リセットボタンの作成
		Button resetButton = new Button();
		resetButton.Size = new Size(100, 30);
		resetButton.Text = "リセット";
		resetButton.Location = new Point(130, form.Height - 80);
		resetButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		resetButton.Parent = form;
		//押した時の処理
		resetButton.Click += delegate (object sender, EventArgs e) {
			for (int i = 0; i < car.Length; i++) {
				car[i].Left = 0;
				pictureBox[i].Left = 0;
				car[i].fuel = 100;
			}
		};

		//フォームを指定して起動
		Application.Run(form);
	}
}
//Carクラスの定義
class Car {
	//フィールドの宣言(protectedより派生クラスからのアクセス可)
	protected Image img;
	private int top = 0;
	protected int left;
	protected int v = 0;    //速度(velocity)
	public int fuel = 100;	//燃料
	//コンストラクタ(オブジェクトの初期化を行う)
	public Car() {
		string png = System.IO.Path.GetFullPath("..\\..\\..\\car.png");
		img = Image.FromFile(png);
	}
	//上書きされる基本クラスのメンバ
	virtual public void Move() {
		fuel = fuel - v;
		if (fuel >= 0) {
			left = left + v;
		}
	}
	//SetImageメソッド、imageフィールドに画像を設定
	public void SetImage(Image i) {
		img = i;
	}
	//GetImageメソッド、画像の取得
	public Image GetImage() {
		return img;
	}
	//Topプロパティの定義
	public int Top {
		//値を設定
		set { top = value; }
		//値の取得
		get { return top; }
	}
	//Leftプロパティ
	public int Left {
		set { left = value; }
		get { return left; }
	}
}
//Carクラスを拡張して、RacingCarクラスを設計
class RacingCar1 : Car {
	public RacingCar1() {
		v = 6;
	}
	////上書きする派生クラスのメンバ
	//override public void Move() {
	//	fuel = fuel - v;
	//	if (fuel >= 0) {
	//		left = left + v;
	//	}
	//}
}
class RacingCar2 : Car {
	public RacingCar2() {
		v = 10;
	}
	//override public void Move() {
	//	fuel = fuel - v;
	//	if (fuel >= 0) {
	//		left = left + v;
	//	}
	//}
}
class RacingCar3 : Car {
	public RacingCar3() {
		v = 2;
	}
	override public void Move() {
		if (fuel >= 0) {
			fuel = fuel -v;
			left = left + v;
			if (left > 20) {
				left = left + 10;
				fuel = fuel - 10;
			}
		}
	}
}
