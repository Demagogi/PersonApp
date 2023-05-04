using System.Text.Json.Serialization;

namespace TestPerson
{

    public class TestPersonObject
    {

        [Fact]
        public void Test1()
        {
            //Arrange
            Program matilda = new Program("Matilda", "Doe", 19, "556", "555");

            //Act
            FileManager.Sw(matilda.Serialize());
            string serializedObject = FileManager.Sr();
            Program newMatilda = Program.Deserialize(serializedObject);

            //Assert
            Assert.Equal(matilda.Name, newMatilda.Name);
            Assert.Equal(matilda.Id, newMatilda.Id);
            Assert.Equal(matilda.ParentId, newMatilda.ParentId);
        }

        [Fact]
        public void Test2() 
        {
            //Arrange
            Program jon = new Program(name: "Jon", surname: "Doe", age: 40, id: "555", parentId: "554");
            Program matilda = new Program("Matilda", "Doe", 19, "556", "555");

            jon.Children.Add(matilda);

            //Act
            FileManager.Sw(jon.Serialize());
            string serializedObject = FileManager.Sr();
            Program newJon = Program.Deserialize(serializedObject);

            //Assert
            Assert.Equal(jon.Name, newJon.Name);
            Assert.Equal(jon.Id, newJon.Id);
            Assert.Equal(jon.ParentId, newJon.ParentId);
        }

        [Fact]
        public void Test3() 
        {
            //Arrange
            Program rocky = new Program("Rocky", "Doe", 68, "554", "553");
            Program jon = new Program(name: "Jon", surname: "Doe", age: 40, id: "555", parentId: "554");
            Program matilda = new Program("Matilda", "Doe", 19, "556", "555");

            rocky.Children.Add(jon);
            jon.Children.Add(matilda);

            //Act
            FileManager.Sw(rocky.Serialize());
            string serializedObject = FileManager.Sr();
            Program newRocky = Program.Deserialize(serializedObject);

            //Assert
            Assert.Equal(rocky.Name, newRocky.Name);
            Assert.Equal(rocky.Id, newRocky.Id);
            Assert.Equal(rocky.ParentId, newRocky.ParentId);
        }
    }
}