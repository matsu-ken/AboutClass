using System.Windows.Forms;
using System.Drawing;

class Sample1 {
  public static void main() {

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
      car[i].Move();
      //メソッドを呼び出して値を取得
      pictureBox[i].Image = car[i].GetImage();
      pictureBox[i].Top = car[i].Top;
      pictureBox[i].Left = car[i].Left;
    }

    //フォームを指定して起動
    Application.Run(form);
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
  virtual public void Move() {
    //上端位置、左端位置を10ずつ移動
    top = top + 10;
    left = left + 10;
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
  //上書きする派生クラスのメンバ
  public override void Move() {
    //上端位置、左端位置を100ずつ移動
    top = top + 100;
    left = left + 100;
  }
}
