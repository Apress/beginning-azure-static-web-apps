namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class Navigation
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Draft,
        Title = "Navigation",
        Tags = new[]
        {
            Constants.CSharp,
            Constants.Blazor
        },
        BlogpostMarkdown = @"Consectetur adipiscing elit. Nulla pharetra purus sit amet dolor facilisis, et placerat mi sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Praesent pellentesque nisi justo, et vestibulum arcu bibendum vitae. Ut sodales lectus vel ex iaculis interdum. Donec porttitor imperdiet ligula, non vulputate nunc elementum ac. Praesent vehicula tempor arcu a tempor. Aenean porttitor, lacus sit amet finibus volutpat, ante enim tristique felis, at tempus leo velit vitae tortor. Suspendisse ultrices purus quis arcu faucibus dictum. Donec blandit facilisis placerat.
Cras sed pretium quam, vel molestie lorem. Morbi interdum dignissim nisl ac ultricies. Mauris congue, mi a egestas egestas, nulla arcu faucibus mi, non vestibulum eros ipsum eu mauris. Morbi faucibus massa in odio accumsan aliquet. Duis tristique ipsum ut lacinia tristique. Praesent porta imperdiet magna. Curabitur a augue in diam tempor finibus eget in velit. Nunc iaculis mollis nulla, sit amet rutrum erat. Aenean eget orci sed dui euismod pellentesque non et tellus. Integer dapibus finibus diam, sit amet maximus magna ultricies at. Aenean ullamcorper felis sed sapien pulvinar faucibus. Morbi ipsum ante, scelerisque nec justo volutpat, efficitur venenatis purus. Mauris in egestas dolor, eget volutpat mi. Sed eu luctus turpis. Aliquam erat volutpat. Nam vitae venenatis tellus.
Cras ultrices nec tellus at porttitor. Maecenas ultricies nec arcu non cursus. Nunc ac dapibus augue, quis aliquam est. In tincidunt, urna eu hendrerit rhoncus, mauris libero convallis ex, eget sodales nunc urna ac lacus. Fusce in leo rhoncus, laoreet dui eget, placerat risus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc sollicitudin dolor libero, quis hendrerit elit accumsan ut. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nullam ut elit diam. Donec fringilla tellus rhoncus sapien placerat, et aliquam eros commodo.
Fusce at tortor risus. Vivamus rutrum odio nibh, sed egestas ante scelerisque vel. Maecenas vitae enim eget eros lacinia tempor. Integer arcu orci, malesuada sed elit eget, tincidunt tincidunt magna. Mauris ut lectus ipsum. Mauris aliquet turpis non nunc efficitur feugiat. Donec vitae lobortis urna. Maecenas luctus, libero sit amet luctus tincidunt, massa urna rhoncus risus, eget vestibulum ligula neque sit amet ipsum. Nulla ornare turpis quis facilisis feugiat.
Cras malesuada dolor in urna imperdiet dictum. Nulla velit libero, condimentum non aliquet eu, mattis pretium risus. Mauris massa lacus, fringilla id massa mollis, vehicula cursus elit. Praesent dignissim ultricies augue, ac lacinia erat laoreet interdum. Nulla sit amet est sem. Nunc non sapien nec eros ullamcorper sodales. Nulla facilisi. Suspendisse potenti. Suspendisse eu scelerisque erat. Nam tellus mi, auctor quis diam ut, sagittis euismod odio. Nullam ultricies pretium est, cursus pulvinar sem auctor eu. Cras auctor, nulla ut blandit convallis, mauris nisl rhoncus dui, sed cursus elit ex a tortor.
Cras eget hendrerit leo. Sed lobortis ut arcu ac dignissim. Maecenas efficitur tempor consectetur. Vestibulum tempor, nisi ac laoreet pulvinar, libero est condimentum ante, in ornare velit turpis tristique augue. Phasellus cursus magna non orci aliquam laoreet. In non lorem."
    };
}
