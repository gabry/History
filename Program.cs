using DBEnum;
using System;
using System.Reflection;
using System.Text;

namespace History
{
    class Program
    {
        public enum Sex
        {
            [DBValue(@"
              ,,,,
             /   '
            /.. /
           ( c  D
            \- '\_
             `-'\)\
                |_ \
                |U \\
               (__,//
               |. \/
               LL__I
                |||
                |||
             ,,-``'\")]
            GrownMale,
            [DBValue(@"
             ,~,;,
           ~(:())))
           ) );),^~;       
          (;(;( o /:       
           )~);)-          
          (;(;(  (_       
         ~;)/* \/*\ \
         (;(* * * *) \
          );`'' `''/ /
          :'\)_,_(/ / 
           \/;;;;;\/
            |  ;  |
            |  _  |
            |_____|
             | | |
             | | |
             |_|_|
             | | |
            <_/|\_>")]
            GrownFemale,
            [DBValue(@"
                  _)_
               .-'(/ '-.
              /    `    \
             /  -     -  \
            (`  a     a  `)
             \     ^     /
              '. '---' .'
              .-`'---'`-.
             /           \
            /  / '   ' \  \
          _/  /|       |\  \_
         `/|\` |+++++++|`/|\`
              /\       /\
              | `-._.-` |
              \   / \   /
              |_ |   | _|
              | _|   |_ |
              (ooO   Ooo)")]
            BabyBoy,
            [DBValue(@"
		    .--..-""""-..--.
		   ///`/////////\`\\\
		   ||/ |///""\\\| \||
             /  -     -  \
            (`  a     a  `)
             \     ^     /
              '.  '=='  .'
              .-`'---'`-.
             /           \
            /  /(_>*<_) \  \
          _/  /|       |\  \_
         `/|\` |+++++++|`/|\`
              /\       /\
              | `-._.-` |
              \   / \   /
              |_ |   | _|
              | _|   |_ |
              (ooO   Ooo)")]
            BabyGirl
        }
        public class Person
        {
            public string Name { get; set; }
            public Sex Sex { get; set; }
            public DateTime BornDate { get; set; }
            public bool IsBornDateExact { get; set; }

            public Person(string name, Sex sex, DateTime bornDate, bool isBornDateExact)
            {
                this.Name = name;
                this.BornDate = bornDate;
                this.IsBornDateExact = isBornDateExact;
                this.Sex = sex;
            }

            public override string ToString()
            {
                return string.Format("{3} >>> Hey! My name is {0} and I {1} {2}", Name, IsBornDateExact ? "was born on" : "will born around", BornDate.ToShortDateString(), Sex.GetDBValue());
            }

            public void Meet(Person me, Person otherPerson, bool isWoman)
            {
                StringBuilder meetMessage = new StringBuilder().Append(string.Format("Hey {0}! My name is {1}", otherPerson.Name, me.Name));
                if (isWoman)
                {
                    meetMessage.Append(" and you like me very much!");
                    meetMessage.AppendLine();
                    meetMessage.AppendLine(@"
  ,o8o, ,o8o,   
,888888,888888,
888888888888888
888888888888888
`8888888888888'
  `888888888'
    `88888'
      `8'");
                }
                Console.WriteLine(meetMessage.ToString());
            }
        }

        public class Zannerini : Person
        {
            public Zannerini(string name, Sex sex, DateTime bornDate, bool isBornDateExact) : base(name, sex, bornDate, isBornDateExact) {
            }

            public Zannerini Join(Person inputPerson, DateTime joinDate, string outputPersonName, Sex outputPersonSex, bool isBornDateExact, DateTime? bornDate = null)
            {
                Console.WriteLine("{0} and {1} are proud to announce the world...", this.Name, inputPerson.Name);
                Suspancer();
                bornDate = isBornDateExact ? bornDate : joinDate.AddMonths(9).AddDays(new Random(DateTime.Now.Millisecond).Next(-7, +7));
                return new Zannerini(outputPersonName, outputPersonSex, bornDate.Value, isBornDateExact);
            }
        }

        static void Main(string[] args)
        {
            var gabriele = new Zannerini("Gabriele", Sex.GrownMale, new DateTime(1984, 8, 14), true);
            Console.WriteLine(gabriele);

            Suspancer();

            var sabrina = new Person("Sabrina", Sex.GrownFemale, new DateTime(1989, 4, 19), true);
            Console.WriteLine(sabrina);

            Suspancer();

            gabriele.Meet(gabriele, sabrina, true);

            Suspancer();

            var mySon = gabriele.Join(sabrina, new DateTime(2018, 5, 25), "Leonardo", Sex.BabyBoy, true, new DateTime(2019, 2, 20, 19, 39, 0));
            Console.WriteLine(mySon);
            
            Suspancer();

            Console.WriteLine(string.Format(Environment.NewLine + "...That's all folks (updated to version {0})...", Assembly.GetExecutingAssembly().GetName().Version));
            Console.ReadLine();
        }

        private static void Suspancer()
        {
            Console.WriteLine(Environment.NewLine + "...some time passes... (press Enter to see how it continues)" + Environment.NewLine);
            Console.ReadLine();
        }
    }
}
