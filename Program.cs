using BlogEf.Data;
using BlogEf.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    #region PrimeiraParte
    // context.Categories.Add(new Category { Name = "Dotnet", Slug = "Dotnet" });
    // context.SaveChanges();
    // context.Categories.ToList();

    // var user = new User
    // {
    //     Name = "Kaicao",
    //     Slug = "Teste",
    //     Email = "kaique@",
    //     Bio = "teste",
    //     Image = "Teste",
    //     PasswordHash = "Teste",
    // };

    // var category = new Category
    // {
    //     Name = "Teste",
    //     Slug = "Teste"
    // };

    //var post = new Post
    //{
    //    Author = user,
    //    Category = category,
    //    Body = "Hello word",
    //    Slug = "Teste",
    //    Summary = "Teste",
    //    Title = "Teste",
    //   CreateDate = DateTime.Now,
    //    LastUpdateDate = DateTime.Now
    //};

    //context.Posts.Add(post);
    //context.SaveChanges();
    #endregion

    #region  SegundaParte
    // context.Users.Add(new User
    // {
    //     Name = "Kaicaoooo",
    //     Email = "Kaicaoooo",
    //     Image = "Kaicaoooo",
    //     Bio = "Kaicaoooo",
    //     PasswordHash = "Kaicaoooo",
    //     Slug = "Kaicaoooo",
    // });

    // context.SaveChanges();

    // var user = context.Users.FirstOrDefault();

    // var post = new Post
    // {
    //     Author = user,
    //     Body = "",
    //     Category = new Category
    //     {
    //         Name = "Alowww",
    //         Slug = "Alowww"
    //     },
    //     CreateDate = DateTime.Now,
    //     // LastUpdateDate =
    //     Slug = "meu-artigo",
    //     Summary = "Nestesa",
    //     // Tags = null,
    //     Title = "Teste",
    // };
    // context.Posts.Add(post);
    // context.SaveChanges();
    #endregion

    // var posts = context.Posts.Include(t => t.Tags).Select(x => new { Id = x.Id, Category = x.Category });
    // foreach (var post in posts)
    // {
    //     Console.WriteLine($"Post {post.Id} {post.Category}");
    // }

    var user = new User
    {
        Name = "Kaiqc",
        Bio = "",
        Email = "tesa",
        GitHub = "",
        Image = "",
        PasswordHash = "sa",
        Slug= "Testeeeeee",
    };

    var category = new Category { Name = "Teste", Slug = "Testeeeeee" };

    var post = new Post
    {
        Author = user,
        CreateDate= DateTime.Now,
        LastUpdateDate= DateTime.Now,
        Title= "Testeeeee",
        Body = "Teste",
        Category = category,
        Slug = "Testeeeeeee",
        Summary = "Teste",
    };

    // context.Posts.Add(post);
    // context.SaveChanges();

    var posts = context.PostWithTagsCount.ToList();
    foreach (var item in posts)
    {
        Console.WriteLine(item.Name);
        Console.WriteLine(item.Count);
    }
}