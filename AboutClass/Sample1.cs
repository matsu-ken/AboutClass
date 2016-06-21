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

		//要素数3の配列を作成
		PictureBox[] pictureBox = new PictureBox[4];
		for (int i = 0; i < pictureBox.Length; i++) {
			//要素数分のピクチャボックスの作成
			pictureBox[i] = new PictureBox();
			pictureBox[i].Parent = form;
		}
		pictureBox[0].Visible = false;
		//要素数4の配列を作成
		Car[] car = new Car[4];
		car[0] = new Car();
		car[1] = new RacingCar();
		car[2] = new RacingCar2();
		car[3] = new RacingCar3();


		for (int i = 0; i < car.Length; i++) {
			//メソッドの呼び出し
			//car[i].Move();
			//メソッドを呼び出して値を取得
			pictureBox[i].Image = car[i].GetImage();
			pictureBox[i].Top = car[i].Top;
			pictureBox[i].Left = car[i].Left;
		}

		//ボタン作成
		Button button = new Button();
		button.Text = "ボタン";
		button.Dock = DockStyle.Bottom;
		button.Parent = form;
		//ボタンのクリック機能
		button.Click += delegate (object sender, EventArgs e) {
			car[1].Move(int.Parse("5"));
			pictureBox[1].Left = car[1].Left;
			car[2].Move(int.Parse("10"));
			pictureBox[2].Left = car[2].Left;
			car[3].Move(int.Parse("1"));
			pictureBox[3].Left = car[3].Left;
		};
		//フォームを指定して起動
		Application.Run(form);
	}
}
//Carクラスの定義
class Car {
	//フィールドの宣言(protectedより派生クラスからアクセス可)
	protected Image img;
	protected int top;
	protected int left;

	//コンストラクタ(オブジェクトの初期化を行う)
	public Car() {
		//位置を0に設定
		top = 0;
		left = 0;
	}
	//上書きされる基本クラスのメンバ
	virtual public void Move(int distance) {
		//上端位置、左端位置を移動
		top = top + distance;
		left = left + distance;
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
class RacingCar : Car {
	public RacingCar() {
		img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
		top = 0;
	}
	//上書きする派生クラスのメンバ
	override public void Move(int distance) {
		//上端位置、左端位置を移動
		top = top + distance;
		left = left + distance;
	}
}

class RacingCar2 : Car {
	public RacingCar2() {
		img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
		top = 75;
	}
	override public void Move(int distance) {
		top = top + distance;
		left = left + distance;
	}
}
class RacingCar3 : Car {
	public RacingCar3() {
		img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
		top = 150;
	}
	override public void Move(int distance) {
		top = top + distance;
		left = left + distance;
	}
}
