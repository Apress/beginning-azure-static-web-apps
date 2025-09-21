namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class FirstStaticWebApp
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Published,
        PublishedDate = new DateTime(2022, 01, 01, 12, 0, 0),
        Title = "Making your first static web app",
        Tags = new[]
        {
            Constants.CSharp,
            Constants.Blazor,
            Constants.Azure,
            Constants.Functions,
            Constants.StaticWebApps
        },
        BlogpostMarkdown = @"**Nullam ullamcorper** ipsum felis, nec sollicitudin eros facilisis sit amet. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur risus elit, pharetra non blandit sed, pretium sed ipsum. Vivamus vel metus sit amet odio commodo dictum in vitae mi. Sed nunc massa, tincidunt eget facilisis eu, euismod et nisi. Donec est justo, ullamcorper eget massa ut, finibus posuere risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae tellus libero. Sed nec metus ac sem bibendum consequat. Fusce purus magna, volutpat in posuere eu, dapibus in magna. Cras tincidunt nunc vel nibh aliquet porttitor. Proin pellentesque magna non neque aliquet dictum sed sed lectus. Suspendisse in rutrum nunc.

Sed risus felis, fermentum vitae imperdiet sit amet, euismod id augue. Phasellus id velit ac ex egestas finibus. Vivamus sodales nulla in dui scelerisque consequat. Sed et feugiat nisi. Proin lacus tortor, fermentum nec magna sit amet, condimentum pellentesque eros. Praesent semper eleifend massa eu convallis. Quisque mattis molestie massa quis venenatis. In hac habitasse platea dictumst. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi rhoncus aliquam suscipit. Proin quis risus sagittis, finibus turpis nec, scelerisque libero. Vestibulum egestas imperdiet nisi, a viverra dui dapibus eget. Curabitur aliquet elit a sem lacinia, vel rhoncus metus pellentesque. Donec tristique purus nisl.

Nam fermentum pulvinar turpis, sit amet tempus magna egestas egestas. Praesent aliquam purus sit amet sagittis rutrum. Donec ipsum neque, accumsan ac eleifend non, malesuada non nulla. Nam pulvinar lorem ut ipsum varius semper. Integer non molestie massa. Phasellus viverra leo quis felis venenatis, eu blandit velit ultrices. Phasellus mollis id libero in commodo.

Fusce interdum in nulla semper scelerisque. Donec massa odio, aliquet ac cursus non, bibendum ac turpis. Nullam id mauris efficitur, placerat."
    };
}
