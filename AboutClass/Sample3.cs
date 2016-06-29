using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//静的クラス
namespace AboutClass {
	class Program {
		static void Main(string[] args) {
			Person taro = new Person("taro", 30);
			Person hanako = new Person("hanako", 24);

			PersonUtility.person = taro;
			PersonUtility.print();
			PersonUtility.person = hanako;
			PersonUtility.print();

			Console.ReadKey();
		}
	}

	class Person {
		public string name;
		public int age;

		public Person() {
			name = "";
			age = 0;
		}
		public Person(string s, int n) {
			name = s;
			age = n;
		}

		public string getData() {
			string data = name + "（" + age + "）";
			return data;
		}
	}

	static class PersonUtility {
		public static Person person;

		public static void print() {
			if (person == null) {
				return;
			}
			string data = person.getData();
			Console.WriteLine("***** print by PersonUtility *****");
			Console.WriteLine(data);
			Console.WriteLine("***** end *****\n");
		}

	}
}
