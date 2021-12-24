using System;
using System.IO;
using System.Text;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        private Guid id;
        private string name;
        private int age;
        private FullAddress address;
        private BehaviorEnum behavior;
        private Letter letter;

        public Child(string name, int age, FullAddress address, BehaviorEnum behavior)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.behavior = behavior;
            this.letter = new Letter();
            this.id = Guid.NewGuid();
        }

        public Child(string path)
        {
            string[] lines = File.ReadAllLines(path);
            letter = new Letter();
            id = Guid.NewGuid();
            char[] whiteSpaceSeparator = new char[] { ' ' };

            string[] tokens;
            string[] addressFields;
            tokens = lines[1].Split(whiteSpaceSeparator, 3, StringSplitOptions.RemoveEmptyEntries);
            name = tokens[2];

            tokens = lines[2].Split(whiteSpaceSeparator, 9, StringSplitOptions.RemoveEmptyEntries);
            age = int.Parse(tokens[2]);

            tokens = tokens[8].Split('.');
            addressFields = tokens[0].Trim().Split(',');
            address = new FullAddress(addressFields[0].Trim(), addressFields[1].Trim(), addressFields[2].Trim());

            tokens = tokens[1].Split(whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
            behavior = String.Compare(tokens[5], "good") == 0 ? BehaviorEnum.Good : BehaviorEnum.Bad;

            tokens = lines[4].Split(',');
            foreach (string token in tokens)
            {
                letter.addItem(new Item(token.Trim()));
            }
        }

        public string Name
        {
            get { return name; }
        }
        public int Age
        {
            get { return age; }
        }
        public FullAddress Address
        {
            get { return address; }
        }
        public BehaviorEnum Behavior
        {
            get { return behavior; }
        }
        public Letter Letter
        {
            get { return letter; }
        }

        public Guid Id
        {
            get { return id; }
        }

        public void addItemToLetter(Item item)
        {
            letter.addItem(item);
        }

        public void writeLetter(string path)
        { 
            StreamWriter writer = new StreamWriter(path);
            StringBuilder letterString = new StringBuilder();

            letterString.Append($"Dear Santa, \nI am {name} \nI am {age} years old.\n" +
                $"I live at {address}. I have been a very {(behavior.Equals(BehaviorEnum.Good) ? "good" : "bad")} child this year\n" +
                "What I would like the most this Christmas is:\n");

            for (int i = 0; i < letter.Items.Count - 1; ++i)
            {
                letterString.Append($"{letter.Items[i].Name}, ");
            }
            letterString.Append(letter.Items[letter.Items.Count - 1].Name);

            writer.Write(letterString);
            writer.Close();
        }

        public override string ToString()
        {
            return $"Child ID: {id.ToString()}\nChild name: {name}\n" +
                $"Child birth date: {age}\n" +
                $"Child address: {address}\n" +
                $"Child behavior: {(behavior.Equals(BehaviorEnum.Good) ? "good" : "bad")}\n" +
                $"Child letter:\n{letter}";
        }
    }
}
