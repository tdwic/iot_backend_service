namespace IoTBackend.Models
{
    public class DistanceDataReturnModel
    {
        public string? Id { get; set; }
        public float LatestDistance { get; set; }
        public List<DistanceDataFetchModel>? DistanceDataFetchModelList { get; set; }
    }
}
