namespace StoreRestoreTabs
{
    [Command(PackageIds.RestoreTabsCommand)]
    internal sealed class RestoreTabsCommand : BaseCommand<RestoreTabsCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var options = await General.GetLiveInstanceAsync();
            foreach (var path in options.CurrentTabs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var documentView = await VS.Documents.OpenAsync(path);
            }
        }
    }
}
