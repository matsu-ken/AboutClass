//インターフェイスについて
using System;
using System.Windows.Forms;

public interface ISwitch {
  //ChangeChannelメソッド、チャンネルを切り替える機能
  void ChangeChannel(int nextChannel);
}

//TVクラスの定義
public class TV : ISwitch {
  private int channel = 0;
  public TV() {
  }
  //ChangeChannelメソッド
  public void ChangeChannel(int nextChannel) {
    this.channel = nextChannel;
    Console.WriteLine(channel + "に変更されました。");
  }
}
//Humanクラスの定義
public class Human {
  public Human() {
  }
  //PushChannelメソッド
  public void PushChannel(int nextChannel, ISwitch tv) {
    tv.ChangeChannel(nextChannel);
  }
}
//Programクラス
class Program {
	static void Main(string[] args) {
		TV tv1 = new TV();
		Human human = new Human();
		bool judge = true;
		while (judge) {
			string number = Console.ReadLine();
			try {
				human.PushChannel(int.Parse(number), tv1);
			}
			catch {
				if (number == "end") {
					Console.WriteLine("終了します。");
					judge = false;
				}
				else {
					Console.WriteLine("チャンネルを入力してください。");
				}
			}
		}
	}
}