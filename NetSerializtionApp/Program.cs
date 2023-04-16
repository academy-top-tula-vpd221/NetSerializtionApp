using System.Text.Json;
using System.Text.Json.Serialization;

User user = new User()
{
    Id = 12,
    LastName = "Smith",
    FirstName = "Bobby",
    BirthDate = new DateTime(1999, 5, 12),
    Address = new Address() { City = "Moscow", Street = "Tverskaya"},
};

List<User> users = new()
{
    new User()
    {
        Id = 12,
        LastName = "Smith",
        FirstName = "Bobby",
        BirthDate = new DateTime(1999, 5, 12),
        Address = new Address() { City = "Moscow", Street = "Tverskaya"},
    },
    new User()
    {
        Id = 23,
        LastName = "Watson",
        FirstName = "John",
        BirthDate = new DateTime(1987, 11, 22),
        Address = new Address() { City = "Tula", Street = "Lenina"},
    }
};

var options = new JsonSerializerOptions()
{
    WriteIndented = true,
    AllowTrailingCommas = true
};

//string usersJson = JsonSerializer.Serialize(users, options);

//Console.WriteLine(usersJson);

//string userJson = JsonSerializer.Serialize(user, options);

//using (StreamWriter jsonWriter = new StreamWriter("user.json"))
//{
//    jsonWriter.Write(usersJson);
//}

//Console.WriteLine(userJson);

//using(StreamReader jsonReader = new StreamReader("user.json"))
//{
//    string userJson = jsonReader.ReadToEnd();
//    User userNew = JsonSerializer.Deserialize<User>(userJson);

//    Console.WriteLine($"{userNew.Id} {userNew.LastName} {userNew.FirstName}");
//}

using (StreamReader jsonReader = new StreamReader("user.json"))
{
    string userJson = jsonReader.ReadToEnd();
    var usersNew = JsonSerializer.Deserialize<List<User>>(userJson);

    foreach(var u in usersNew)
    {
        Console.WriteLine($"{u.Id} {u.LastName} {u.FirstName} {u.BirthDate.ToLongDateString()}");
        Console.WriteLine($"\t{u.Address.City} {u.Address.Street}");
        Console.WriteLine();
    }
        
}

class User
{
    int code = 111;
    
    [JsonIgnore]
    public int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    
    [JsonPropertyName("Birth Date")]
    public DateTime BirthDate { get; set; }

    public Address Address { get; set; }

}

class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}