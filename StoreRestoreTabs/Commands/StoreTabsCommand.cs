using System.Collections.Generic;
using System.Text;

namespace StoreRestoreTabs
{
    [Command(PackageIds.StoreTabsCommand)]
    internal sealed class StoreTabsCommand : BaseCommand<StoreTabsCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var allTabPaths = new List<string>();
            var allWindows = await VS.Windows.GetAllDocumentWindowsAsync();
            foreach (var allWindow in allWindows)
            {
                var windowView = await allWindow.GetDocumentViewAsync();
                var windowViewPath = windowView?.FilePath;
                if (!string.IsNullOrWhiteSpace(windowViewPath))
                {
                    allTabPaths.Add(windowViewPath);
                }
            }

            var options = await General.GetLiveInstanceAsync();
            var allTabsPathBuilder = new StringBuilder();
            foreach (var tabPath in allTabPaths)
            {
                var documentView = await VS.Documents.GetDocumentViewAsync(tabPath);
                if (documentView != null)
                {
                    var docWindowFrame = documentView.WindowFrame;
                    if (docWindowFrame != null)
                    {
                        var closeFrameResult = await docWindowFrame.CloseFrameAsync(FrameCloseOption.NoSave);
                        if (closeFrameResult)
                        {
                            allTabsPathBuilder.Append(tabPath + "|");
                        }
                    }
                }
            }
            options.CurrentTabs = allTabsPathBuilder.ToString();
        }
    }
}
