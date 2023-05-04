using System.Text;

public class Program
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string ParentId { get; set; }
    public List<Program> Children { get; set; }

    public Program(string name, string surname, int age, string id, string parentId)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Id = id;
        ParentId = parentId;
        Children = new List<Program>();
    }

    public string Serialize()
    {
        // Serialize the Person object to a string
        StringBuilder person = new StringBuilder();
        person.Append(Name).Append(",").Append(Surname).Append(",").Append(Age).Append(",").Append(Id).Append(",").Append(ParentId).Append(";");
   
        foreach (Program child in Children)
        {
            person.Append(child.Serialize());
        }

        return person.ToString();
    }

    public static Program Deserialize(string personAsString)
    {
        // Deserialize the string to a Person object
        string[] people = personAsString.Split(';');
        Program person = null;

        foreach (string human in people)
        {
            if (!string.IsNullOrEmpty(human))
            {
                string[] fields = human.Split(',');
                string name = fields[0];
                string surname = fields[1];
                int age = int.Parse(fields[2]);
                string id = fields[3];
                string parentId = fields[4];

                if (person == null)
                {
                    person = new Program(name, surname, age, id, parentId);
                }
                else
                {
                    Program child = new Program(name, surname, age, id, parentId);
                    person.Children.Add(child);
                }
            }
        }

        return person;
    }
}
