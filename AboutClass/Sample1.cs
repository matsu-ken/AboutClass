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

		//要素数4の配列を作成
		Car[] car = new Car[4];
		car[0] = new Car();
		car[1] = new RacingCar();
		car[2] = new Car();
		car[3] = new Car();


		for (int i = 0; i < car.Length; i++) {
			//メソッドの呼び出し
			//car[i].Move();
			//メソッドを呼び出して値を取得
			pictureBox[i].Image = car[i].GetImage();
			pictureBox[i].Top = car[i].Top;
			pictureBox[i].Left = car[i].Left;
		}

		//string number = Console.ReadLine();
		//car[1].Move(int.Parse(number));
		//pictureBox[1].Top = car[1].Top;
		//pictureBox[1].Left = car[1].Left;
		//ボタン作成
		Button button = new Button();
		button.Text = "ボタン";
		button.Dock = DockStyle.Bottom;
		button.Parent = form;
		//ボタンのクリック機能
		button.Click += delegate (object sender, EventArgs e) {
			car[1].Move(int.Parse("10"));
			pictureBox[1].Left = car[1].Left;
		};
		//フォームを指定して起動
		Application.Run(form);
	}
}
//Carクラスの定義
class Car {
	//フィールドの宣言(protectedより派生クラスからアクセス可)
	public Image img;
	protected int top;
	protected int left;

	//コンストラクタ(オブジェクトの初期化を行う)
	public Car() {
		//画像の読み込み
		img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
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
		img = Image.FromFile("C:\\Users\\matsuoka\\Desktop\\car2.jpg");
		top = 100;
	}
	//上書きする派生クラスのメンバ
	override public void Move(int distance) {
		//上端位置、左端位置を移動
		top = top + distance;
		left = left + distance;
	}
}
