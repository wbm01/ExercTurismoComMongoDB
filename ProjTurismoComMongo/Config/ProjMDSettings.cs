namespace ProjTurismoComMongo.Config
{
    public class ProjMDSettings:IProjMDSettings
    {
        public string ClientCollectionName { get; set; }
        public string AddressCollectionName { get; set; }

        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
