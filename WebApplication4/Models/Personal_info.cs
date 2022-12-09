using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebApplication4.Models
{
    public class Personal_info
    {
       private static SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\gl3\\framework\\project\\2022 GL3 .NET Framework TP3 - SQLite database.db");
        
        public List<Person> GetAllPerson()
        {
          
            connection.Open();
            string queryString = " SELECT * FROM personal_info;";
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            List<Person> list = new List<Person>();
            using (SQLiteDataReader dataReader = command.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["id"];
                        string first_name = (string)dataReader["first_name"];
                        string last_name = (string)dataReader["last_name"];
                        string email = (string)dataReader["email"];
                        //DateTime date_birth = (DateTime)dataReader["date_birth"];
                        string image = (string)dataReader["image"];
                        string country = (string)dataReader["country"];
                        Person person = new Person(id, first_name, last_name, email, image, country);
                        list.Add(person);


                    }
                }

              




            }
            connection.Close();
            return list;
        }
        public List<Person> GetPerson(int id)
        {
            List<Person> list = new List<Person>();

            connection.Open();
            string queryString = " SELECT * FROM personal_info where id=" +id +";" ;
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
           
            
            SQLiteDataReader dataReader = command.ExecuteReader();
            using (dataReader)
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int idd = (int)dataReader["id"];
                    string first_name = (string)dataReader["first_name"];
                    string last_name = (string)dataReader["last_name"];
                    string email = (string)dataReader["email"];
                    //DateTime date_birth = (DateTime)dataReader["date_birth"];
                    string image = (string)dataReader["image"];
                    string country = (string)dataReader["country"];
                    Person person=new Person(idd,first_name,last_name, email, image, country);   
                    list.Add(person);
                    }

                }
                

            }
            connection.Close();
            return list;
        }
        public int trouvePerson(string name,string country)
        {
            List<Person> list = this.GetAllPerson();
            foreach (Person person in list)
            {
                if (person.first_name == name && person.country == country)
                { 
                    return person.id;
                }
            }
                return -1;


        }
    }
}
