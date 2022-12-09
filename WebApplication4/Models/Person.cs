namespace WebApplication4.Models
{
    public class Person
    {
        public int id;
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        //   private DateTime date_birth { get; set; }
        public string image { get; set; }
        public string country { get; set; }
        public Person()
        {

        }
        public Person(int id,string first_name,string last_name,string email,string image,string country) { 
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;     
            this.email = email;
           // this.date_birth = date_birth;
            this.image = image;     
            this.country = country;
                                    
            }
        public Person(string first_name, string country)
        {

            this.first_name = first_name;
            this.country = country;

        }
    
        /*
        public DateTime getDate_birth()
        {
            return this.date_birth;
        }
        */
     


    }
}
