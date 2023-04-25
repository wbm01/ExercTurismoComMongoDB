namespace ProjTurismoComMongo.Config
{
    public interface IProjMDSettings
    {
        string ClientCollectionName { get; set; }
        string AddressCollectionName { get; set; }

        string CityCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
