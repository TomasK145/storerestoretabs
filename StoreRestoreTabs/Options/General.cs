using System.ComponentModel;
using System.Runtime.InteropServices;

namespace StoreRestoreTabs
{
    internal partial class OptionsProvider
    {
        // Register the options with this attribute on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "StoreRestoreTabs", "General", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("General")]
        [DisplayName("Current tabs")]
        [Description("Contains current tabs.")]
        [DefaultValue("")]
        public string CurrentTabs { get; set; }
    }
}
