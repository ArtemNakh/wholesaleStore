namespace wholesaleStore.Models
{
    public class CreateGoodsRequest
    {
        public string Title { get; set; }
        public int Numbers { get; set; }
        public string Maker { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
