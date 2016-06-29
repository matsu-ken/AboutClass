using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//抽象クラスについて
namespace AboutClass {
	class Sample4 {
		static void Main(string[] args) {
			Student hanako = new Student("hanako", 2);
			Employee jiro = new Employee("jiro", "営業", "係長");

			Console.WriteLine(hanako.getData());
			Console.WriteLine(jiro.getData());

			Console.ReadKey();
		}
	}

	//抽象クラス
	abstract class Person {
		public string name;

		public abstract string getData();
	}

	//実装クラス1
	class Student : Person {
		public int grade;

		public Student(string name, int grade) {
			this.name = name;
			this.grade = grade;
		}

		public override string getData() {
			return name + " [" + grade + "年生]";
		}
	}

	//実装クラス2
	class Employee : Person {
		public string section;
		public string position;

		public Employee(string name, string section, string position) {
			this.name = name;
			this.section = section;
			this.position = position;
		}

		public override string getData() {
			return section + "課" + position + ":" + name;
		}
	}
}
