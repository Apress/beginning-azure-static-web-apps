namespace Models;
public record Blogpost(
    Guid Id,
    string Title,
    string Author,
    DateTime PublishedDate,
    string[] Tags,
    string BlogpostMarkdown,
    bool? PreviewIsComplete = null
);