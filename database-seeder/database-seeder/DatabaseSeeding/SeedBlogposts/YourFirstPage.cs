namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class YourFirstPage
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Published,
        PublishedDate = new DateTime(2022, 03, 01, 12, 0, 0),
        Title = "Your First Page",
        Tags = new[]
        {
            Constants.CSharp,
            Constants.Blazor
        },
        BlogpostMarkdown = @"Consectetur adipiscing elit. Mauris suscipit laoreet enim eleifend elementum. Nam tellus urna, sodales sit amet facilisis vel, sollicitudin sed lorem. Donec tincidunt nisl ut molestie ultricies. Pellentesque posuere libero ac aliquam elementum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec placerat eget ante ut molestie. Praesent vehicula consequat tortor. Praesent accumsan leo lorem, at finibus turpis semper et. Aliquam varius vehicula purus non congue. Pellentesque consectetur viverra mattis. Donec ac facilisis nunc, et vulputate dolor. Nulla fringilla consectetur libero viverra cursus. Vestibulum tempus arcu dolor, vitae varius eros efficitur vitae.
Morbi lacinia, nunc non aliquet tempus, est enim maximus dui, vel tristique tellus dui sit amet turpis. Curabitur dictum semper nisl, sed imperdiet nisi fermentum ut. Donec in dictum massa, ac varius ligula. Vestibulum gravida tincidunt leo. Praesent dignissim gravida odio et tristique. Suspendisse vel interdum est, eu suscipit augue. Pellentesque egestas orci vulputate orci volutpat porttitor. Mauris tristique, nisi sed feugiat placerat, tortor magna vehicula orci, ac vehicula ipsum leo pretium nunc. Mauris pharetra, lacus id viverra euismod, erat massa malesuada velit, non molestie velit diam non ligula. Morbi purus orci, tincidunt eget elit sed, sagittis pharetra justo. Nam vitae tincidunt purus. Praesent cursus dapibus lacus id pulvinar. In eleifend, nisi a rhoncus pharetra, nulla felis finibus turpis, sit amet vulputate dui justo vitae ante. Phasellus non nulla turpis. Praesent nec enim eros. Curabitur feugiat, lectus non luctus pharetra, enim ex finibus sapien, vitae consectetur quam dui id neque.
Suspendisse congue vitae orci mollis condimentum. Vestibulum luctus libero vitae lacus sagittis, at luctus sapien sodales. Aliquam a diam eget lorem suscipit molestie blandit ut libero. Phasellus sed mi ut tellus vulputate posuere sit amet at ante. Ut feugiat, ex ut fringilla congue, justo odio luctus ipsum, vitae elementum ligula tortor placerat dui. Suspendisse suscipit vulputate quam, in fermentum mi varius quis. Nullam mollis massa ac lobortis posuere. Phasellus eu velit vulputate, bibendum erat non, maximus elit. Ut ut velit nec nisi tincidunt eleifend. Phasellus convallis volutpat tortor, non lobortis diam efficitur non. Aliquam vitae fermentum nibh, faucibus consequat.
"
    };
}
