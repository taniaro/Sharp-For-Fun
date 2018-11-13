
using System.Collections.Generic;


namespace SparseMatrix
{
    //клас, що представляє клітинку матриці
    public class SparseCell
    {
        public int value;
        public List<int> coord;

        public SparseCell() { }
        public SparseCell(int value, List<int> coord)
        {
            this.value = value;
            this.coord = coord;
        }
    }
}
