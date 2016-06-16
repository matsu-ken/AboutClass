using System.Windows.Forms;
using System.Drawing;

class Sample1 {
  public static void Main() {

    //フォームの作成
    Form form = new Form();
    form.Text = "サンプル";
    form.Width = 300;
    form.Height = 200;

    //ピクチャボックスの作成
    PictureBox pictureBox = new PictureBox();

    //オブジェクトの作成
    Car car = new Car();
    //メソッドの呼び出し
    car.Move();
    car.Move();

    //フィールドを介してフィールドにアクセス
    pictureBox.Image = car.GetImage();
    //プロパティを介してフィールドにアクセス
    pictureBox.Top = car.Top;
    pictureBox.Left = car.Left;

    //ピクチャボックスをフォーム上にのせる
    pictureBox.Parent = form;
    //フォームを指定して起動
    Application.Run(form);
  }
}
//Carクラスの定義
class Car {
  //フィールドの宣言(privateよりクラス外部からアクセス不可)
  private Image img;
  private int top;
  private int left;
  //コンストラクタ(オブジェクトの初期化を行う)
  public Car() {
    //画像の読み込み
    img = Image.FromFile("C:\\Users\\matsuoka\\Documents\\work_place\\AboutClass\\car.png");
    //位置を0に設定
    top = 0;
    left = 0;
  }
  //Moveメソッドの定義
  public void Move() {
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