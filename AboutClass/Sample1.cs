using System.Windows.Forms;
using System.Drawing;
using System;

class Sample1 {
	public static void Main() {

		//フォームの作成
		Form form = new Form();
		form.Text = "サンプル";
		form.Width = 600;
		form.Height = 300;

		//要素数3の配列を作成(PictureBox)
		PictureBox[] pictureBox = new PictureBox[3];
			for (int i = 0; i < pictureBox.Length; i++) {
			//要素数分のオブジェクトの作成
			pictureBox[i] = new PictureBox();
			//要素数分のオブジェクトをフォーム上にのせる
			pictureBox[i].Parent = form;
		}

		//要素数3の配列を作成(Car)
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
		//要素数3の配列を作成(Label)
		Label[] label = new Label[3];
		string[] position = new string[3] { "上", "中", "下" };
		for (int i = 0; i < label.Length; i++) {
			label[i] = new Label();
			label[i].Text = car[i] + " (" + position[i] + ")\n残量：" + car[i].fuel + "/" + car[i].fuelMax;
			label[i].Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			label[i].Parent = form;
		}
		label[0].Location = new Point(250, form.Height - 80);
		label[1].Location = new Point(360, form.Height - 80);
		label[2].Location = new Point(470, form.Height - 80);
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
				if(car[i].fuel >= 0) {
					label[i].Text = car[i] + " (" + position[i] + ")\n残量：" + car[i].fuel + "/" + car[i].fuelMax;
				}
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
				car[i].fuel = car[i].fuelMax;
				label[i].Text = car[i] + " (" + position[i] + ")\n残量：" + car[i].fuel + "/" + car[i].fuelMax;
			}
		};
		
		//フォームを指定して起動
		Application.Run(form);
	}
}
//Carクラスの定義
class Car {
	//フィールドの宣言
	public Image img;
	private int top;
	protected int left;
	public int v;		//速度(velocity)
	public int fuel;    //燃料
	public int fuelMax;
	//コンストラクタ(オブジェクトの初期化を行う)
	public Car() {
		string png = System.IO.Path.GetFullPath("..\\..\\..\\car.png");
		img = Image.FromFile(png);
		fuel = 500;
		fuelMax = 500;
	}
	//上書きされる基本クラスのメンバ
	public virtual void Move() {
		fuel -= v;
		if (fuel >= 0) {
			left += v;
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
		v = 8;
	}
}
class RacingCar2 : Car {
	public RacingCar2() {
		v = 10;
	}
}
class RacingCar3 : Car {
	public RacingCar3() {
		v = 2;
	}
	 public override void Move() {
		if (fuel > 0) {
			fuel -= v;
			left += v;
			if (left >= 50) {
				left += 10;
				fuel -= 10;
			}
		}
	}
}
