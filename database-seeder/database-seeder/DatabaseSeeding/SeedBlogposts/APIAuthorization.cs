namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class APIAuthorization
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Draft,
        Title = "API Authorization",
        Tags = new[]
        {
            Constants.Azure,
            Constants.StaticWebApps,
            Constants.Functions
        },
        BlogpostMarkdown = @"Morbi efficitur diam nec leo hendrerit imperdiet. Mauris ullamcorper tempus justo, ut gravida felis facilisis ut. Mauris consequat sed sem sed egestas. Pellentesque ullamcorper, velit ac vestibulum egestas, sapien ipsum malesuada eros, vel facilisis justo ligula tincidunt ante. Donec suscipit ante mattis ex auctor congue. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam egestas dui quis diam egestas, non dictum ipsum vestibulum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Phasellus nisi purus, molestie pellentesque turpis aliquam, tempus facilisis lorem. Sed feugiat tincidunt consequat. Suspendisse sed lectus sit amet quam scelerisque egestas lacinia id risus.

Pellentesque viverra sapien a sapien varius blandit. Suspendisse sollicitudin metus nec nisl ultrices lobortis. Quisque nec blandit odio. Vivamus eu tortor dapibus, rutrum diam non, molestie nulla. Pellentesque et nulla rutrum, varius ipsum iaculis, varius lacus. Mauris at viverra quam. Curabitur aliquam diam ac orci fringilla pretium.

Aliquam erat volutpat. Nullam a hendrerit risus. Quisque scelerisque dui eu nibh pellentesque convallis. Duis consequat odio sed vestibulum iaculis. Maecenas sed magna quis magna efficitur consectetur. Duis auctor massa risus, quis viverra eros tincidunt vitae. Proin gravida pulvinar tincidunt. Quisque malesuada dui eu sollicitudin interdum. Duis a consequat diam, vitae pretium dui. Pellentesque ex urna, euismod eu ipsum vitae, aliquam posuere arcu. Nunc eu ligula id libero molestie tempor.

Etiam eu gravida dolor, nec varius dui. Maecenas pharetra dui suscipit sollicitudin tincidunt. Sed dapibus eleifend bibendum. Quisque vehicula luctus neque. Integer eget fermentum metus. Quisque luctus justo sed ipsum lacinia, fermentum ornare dolor vulputate. Nulla ut tempus nulla, tristique consectetur lacus.

Praesent tempus est ex. Aenean venenatis egestas justo vel imperdiet. Aenean id leo et mi sagittis faucibus in ut orci. Etiam ut metus enim. Nunc ullamcorper cursus nisi in euismod. Mauris rhoncus nisl vel sodales aliquet. Proin nec laoreet massa, et vehicula orci. Proin vel feugiat eros. Sed sed libero eu dolor accumsan consectetur a eu sem. Suspendisse ut tempor mauris, vel imperdiet nibh. Donec pellentesque nisi justo, condimentum tincidunt sapien condimentum sed. Ut porta elit sed nisl dignissim, in aliquet nisi posuere. Nullam faucibus id magna et sollicitudin.

Nullam eros dolor, ultrices eget pulvinar nec, hendrerit vitae dolor. Nullam a pulvinar justo. Ut id nunc quis massa consequat viverra. Nulla eu egestas velit, at porttitor ipsum. Aliquam sit amet purus laoreet, ullamcorper risus vel, vulputate dolor. Nunc sodales elementum diam vel tristique. Aenean tincidunt sem vitae velit euismod venenatis et vitae risus. Duis nec molestie ex. In hac habitasse platea dictumst. Proin eu libero a eros volutpat sagittis id sit amet mauris. Praesent pharetra magna elit, nec auctor leo rhoncus in. Aliquam facilisis aliquam risus sit amet.
"
    };
}
