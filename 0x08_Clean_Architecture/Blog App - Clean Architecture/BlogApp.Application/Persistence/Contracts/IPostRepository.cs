using BlogApp.Domain;

namespace BlogApp.Application.Persistence.Contracts;

public interface IPostRepository<T> : IGenericRepository<Post>
{
    Task<Post> UpdateTitle (int id, string title);
    Task<Post> UpdateContent (int id, string content);
}