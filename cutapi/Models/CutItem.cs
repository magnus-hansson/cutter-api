using System.Collections.Generic;
namespace CutApi.Models
{
    public class CutItem
    {
        public int BaseLength { get; set; }
        public List<Length> CutLength { get; set; }
    }
    public class Length
    {
        public int Id { get; set; }
        public int NumberOfItems { get; set; }
        public int CutLength { get; set; }
    }

}