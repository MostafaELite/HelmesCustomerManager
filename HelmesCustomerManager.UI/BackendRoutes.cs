namespace HelmesCustomerManager.UI
{
    internal class BackendRoutes
    {
        internal const string SectorEndpoint= "sectors";
        internal const string CustomerEndpoint = "customer";

        public static string ForCustomer(Guid customerId) => $"{CustomerEndpoint}/{customerId}";
    }
}
