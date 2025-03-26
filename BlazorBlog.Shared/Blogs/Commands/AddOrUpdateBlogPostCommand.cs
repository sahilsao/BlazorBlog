namespace BlazorBlog.Shared.Blogs.Commands;

public class AddOrUpdateBlogPostCommand
{
    public Guid? Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}