
using VotingApp.Data;
using VotingApp.Entities;
using VotingApp.Methods;

using VotingAppDbContext context = new();

// Username Giriş
Console.WriteLine("Username: ");
string usernameLogin = Console.ReadLine();

var existUser = context.Users.FirstOrDefault(x => x.Username.Equals(usernameLogin));

// Username yoksa
if (existUser == null)
{
    Console.WriteLine("Lütfen Kayıt Olun!");
    Console.WriteLine("Username: ");
    string username = Console.ReadLine();


    context.Users.Add(new User { Username = username});
    context.SaveChanges();

    Console.WriteLine("Kayıt Başarılı");

    CategoryVoting.Vote();
}
// Username varsa
else
{
    CategoryVoting.Vote();
}

Console.Read();




