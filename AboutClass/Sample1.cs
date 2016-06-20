using System.Windows.Forms;
using System.Drawing;
using System;

class Sample1 {
  public static void Main() {

    //フォームの作成
    Form form = new Form();
    form.Text = "サンプル";
    form.Width = 300;
    form.Height = 200;

    //要素数2の配列を作成
    PictureBox[] pictureBox = new PictureBox[2];

    for (int i = 0; i < pictureBox.Length; i++) {
      //要素数分のピクチャボックスの作成
      pictureBox[i] = new PictureBox();
      //要素数分のピクチャボックスをフォームにのせる
      pictureBox[i].Parent = form;
    }

    //要素数2の配列を作成
    Car[] car = new Car[2];
    car[0] = new Car();
    car[1] = new RacingCar();

    for (int i = 0; i < car.Length; i++) {
      //メソッドの呼び出し
      //car[i].Move();
      //メソッドを呼び出して値を取得
      pictureBox[i].Image = car[i].GetImage();
      pictureBox[i].Top = car[i].Top;
      pictureBox[i].Left = car[i].Left;
    }

		string number = Console.ReadLine();
		car[1].Move(int.Parse(number));
		pictureBox[1].Top = car[1].Top;
		pictureBox[1].Left = car[1].Left;
		//ボタン作成
		Button button = new Button();
		button.Text = "ボタン";
		button.Dock = DockStyle.Bottom;
		button.Parent = form;

		//フォームを指定して起動
		Application.Run(form);
	}
	//ボタンイベント
	public static void button_Click(object sender, EventArgs e) {

	}
}
//Carクラスの定義
class Car {
  //フィールドの宣言(privateよりクラス外部からアクセス不可)
  private Image img;
  //protectedより派生クラスからアクセス可
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
		//img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
	}
	//上書きする派生クラスのメンバ
	public override void Move(int distance) {
    //上端位置、左端位置を移動
    top = top + distance;
    left = left + distance;
  }
}
