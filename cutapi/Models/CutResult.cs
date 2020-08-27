using System.Collections.Generic;
namespace CutApi.Models
{
    public class CutResult
    {
        public int BaseLength { get; set; }
        public int WasteLength { get; set; }
        public List<int> CutLengths { get; } = new List<int>();
    }


}