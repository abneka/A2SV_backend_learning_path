using BlogApp.Domain;

namespace BlogApp.Application.Persistence.Contracts;

public interface ICommentRepository<T> : IGenericRepository<Comment>
{
    Task<Comment> UpdateText (int id, string text);
    Task<IReadOnlyList<Comment>> GetCommentsByPostId(int postId);
}