using System;
using DevExpress.ExpressApp.Xpo;

namespace XafBlazorDocker.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
