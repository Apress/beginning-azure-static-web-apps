namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class LoadingFromApi
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Published,
        PublishedDate = new DateTime(2022, 02, 01, 12, 0, 0),
        Title = "Loading From an API",
        Tags = new[]
        {
            Constants.CSharp,
            Constants.Azure,
            Constants.Functions,
        },
        BlogpostMarkdown = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pretium id lectus nec vestibulum. Nam consectetur, turpis ac tempor iaculis, nulla dui pharetra magna, eu blandit felis dolor eget dolor. Donec aliquet sapien nec leo convallis, non venenatis diam imperdiet. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris metus augue, dictum ut felis non, ultricies aliquet nunc. Sed interdum sapien sed tortor molestie mattis. Maecenas efficitur libero eu metus gravida, facilisis aliquam tortor lacinia. Mauris at quam volutpat, rhoncus lacus imperdiet, feugiat enim. Curabitur scelerisque et lorem a tincidunt. Sed in mauris et mauris lobortis luctus. Donec erat ligula, consectetur a eleifend dapibus, ornare sed neque. Donec condimentum porttitor sem, at imperdiet odio ultrices in. Morbi vitae iaculis orci. Praesent feugiat eros ut pellentesque dapibus.

## Mauris posuere et quam a suscipit

Vestibulum ut commodo sem. Sed ac justo ac metus finibus fermentum. Cras ultricies eros a magna placerat, nec aliquam magna tincidunt. Maecenas in consequat felis, eget finibus tellus. Curabitur eget venenatis leo. Quisque ullamcorper vulputate posuere. Suspendisse egestas mi in lobortis vestibulum. Aenean sagittis tellus erat, at semper neque aliquam nec. Pellentesque gravida quam massa, et vestibulum mi suscipit sit amet. Morbi lacinia urna quis finibus tristique. Proin odio mauris, scelerisque sit amet tempor quis, commodo nec arcu. Phasellus pretium ut urna ac feugiat.
Integer aliquet aliquam sem at vestibulum. Proin condimentum vel ipsum in ornare. Vestibulum sed ante tellus. Suspendisse molestie vulputate nibh, eu tincidunt magna congue eu. Vivamus pulvinar nisl vitae dignissim placerat. Praesent et consequat eros, quis pulvinar erat. Donec a tincidunt massa, vitae vehicula quam.
Sed aliquet eleifend vulputate. Maecenas nec magna commodo, fermentum erat vitae, mollis dui. Maecenas tincidunt luctus quam in finibus. Etiam ac sodales mi. Vivamus a porta ante. Donec in eros at sapien tristique bibendum. Aenean tellus lacus, mollis non augue a, imperdiet molestie lectus. Nullam et eros at tortor pharetra feugiat.
Cras et porttitor lorem. Nulla facilisi. Curabitur quis pulvinar arcu. Pellentesque consequat ante a auctor sodales. In et nisi vitae nibh rhoncus vehicula. Cras varius mi finibus massa luctus vulputate. Proin pellentesque accumsan arcu.

* Donec viverra sit amet ipsum a pharetra
* Orci varius natoque penatibus et magnis dis parturient montes
* Nascetur ridiculus mus

Sed mattis sollicitudin ante, id maximus purus venenatis sed. Integer convallis semper risus, vel lacinia ipsum interdum id. Integer quis bibendum leo. Etiam."
    };
}
