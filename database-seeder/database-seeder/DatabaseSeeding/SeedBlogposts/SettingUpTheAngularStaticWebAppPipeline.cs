namespace CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;

internal static class SettingUpTheAngularStaticWebAppPipeline
{
    internal static Blogpost Blogpost = new()
    {
        Id = Guid.NewGuid(),
        Author = GlobalConstants.Author,
        Status = Status.Draft,
        Title = "Setting Up The Angular Static Web App Pipeline",
        Tags = new[]
        {
            Constants.Angular,
            Constants.StaticWebApps
        },
        BlogpostMarkdown = @"Donec eget sapien a velit aliquet dictum non eget quam. Suspendisse tristique ultricies venenatis. Fusce vehicula augue malesuada turpis malesuada, nec volutpat mauris malesuada. Pellentesque mattis nisi vel dolor sagittis, vel placerat nunc consequat. Proin quis augue in purus rutrum sagittis a non turpis. Vivamus id pharetra dolor. Aenean id enim blandit leo posuere cursus tincidunt id diam. Donec sodales non quam a posuere. Pellentesque porttitor est non ligula faucibus accumsan. Curabitur vel erat quis lacus pulvinar suscipit. Etiam ornare, ante non congue aliquam, nisi ligula porta mauris, eu dignissim justo urna non nunc. Phasellus pretium rhoncus fermentum. Nullam vel eleifend augue, nec elementum risus.

Aliquam tortor lacus, imperdiet nec volutpat quis, venenatis vel quam. In consectetur, purus nec porttitor semper, nisi urna pharetra ex, ac bibendum dolor mauris non odio. Sed pulvinar ligula risus, ac sodales orci pulvinar eu. Morbi vulputate dolor vitae justo rhoncus, et molestie metus cursus. Proin risus nunc, egestas vitae pellentesque vitae, porttitor nec risus. Proin lectus dolor, vestibulum nec nulla eget, fermentum malesuada diam. Vivamus consectetur sagittis pharetra. Aenean eleifend sapien eu sem vehicula lacinia. Suspendisse quis molestie eros, ac imperdiet odio. Integer fermentum iaculis libero, nec pretium nibh mattis sed.

Vivamus ipsum lacus, fermentum eget lacinia vel, vestibulum at velit. Nulla a turpis eu quam elementum interdum at nec felis. Sed non justo consequat, efficitur tellus sit amet, efficitur nibh. Integer placerat, augue eget pretium maximus, lacus enim commodo ante, at feugiat enim massa nec purus. Proin non tincidunt ligula. Nunc in quam blandit, tempor orci at, ultricies est. Vestibulum sollicitudin nibh urna, a venenatis sapien ultricies sit amet. Nulla rutrum nisi quis metus ornare viverra. Curabitur non commodo velit. Fusce eget neque sapien. Etiam consequat risus vitae elementum consequat. Ut tempus non est a tristique. Fusce cursus mauris nibh, ut vehicula odio volutpat non.

Maecenas sagittis tellus non sapien fermentum, non laoreet dolor vulputate. Sed in dui tempor, scelerisque odio non, imperdiet diam. Phasellus nisi magna, semper quis lacinia faucibus, pulvinar a leo. Integer a mi felis. Proin ac purus ac dolor molestie molestie. Duis sodales, lorem tempus mollis malesuada, enim ante mattis erat, et eleifend nisl magna quis mauris. Vestibulum eu interdum massa, tempus pulvinar sapien. Nullam pellentesque nec ex eu tempus. Phasellus eu elit et justo euismod scelerisque. Maecenas eleifend nibh in metus elementum, ac efficitur lacus lacinia. Cras imperdiet lectus non congue ultricies. Sed bibendum mollis mauris, et sagittis dui semper in. In hac habitasse platea dictumst. Nullam egestas ac enim sed condimentum. Etiam vulputate diam sed dictum sollicitudin.

Morbi nisl massa, ultricies vitae varius eu, ullamcorper ut lectus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis suscipit ipsum nec sem malesuada ornare. Phasellus auctor porta risus. Sed a odio sit amet massa venenatis accumsan. Sed rutrum tortor sed nunc faucibus volutpat. Duis ac eleifend velit, in aliquet magna. Pellentesque sit amet nisl convallis, maximus felis eu, molestie sem. Ut rutrum rhoncus."
    };
}
