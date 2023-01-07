using System.Runtime.CompilerServices;
using VotingApp.Data;
using VotingApp.Entities;

namespace VotingApp.Methods
{
    public class CategoryVoting
    {
        public static void Vote()
        {
            using VotingAppDbContext context = new();

            var categories = context.Categories.ToList();
           
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id}-{category.CategoryName}");
            }

            Console.WriteLine("Kategori numarasını yazıp enter'a basın.");

            int vote = int.Parse(Console.ReadLine());


            Category votingCategory = context.Categories.FirstOrDefault(x => x.Id == vote);
            if (votingCategory == null)
            {
                Console.WriteLine("Kategori Bulunamadı!");
            }
            else
            {
                votingCategory.Vote += 1;
                context.Categories.Update(votingCategory);
                context.SaveChanges();
            }


            int TotalVoting = context.Categories.Sum(x => x.Vote);


            foreach (var category in categories)
            {
                int percentVote = (category.Vote) / (TotalVoting) * 100;
                Console.WriteLine($"Category: {category.CategoryName} Total Vote: {category.Vote} Oran: %{percentVote}");
            }
        }
    }
}
