using System.Collections;

namespace ConsoleApp4
{
    enum Fields
    {
        Ad,
        Soyad,
        Yas,
        Sehir
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataRow row = new DataRow();
            row.AddValue("Sümeyra");
            row.AddValue("Altınışık");
            row.AddValue(22);
            row.AddValue("Istanbul");            

            DataTable dataTable = new DataTable();
            dataTable.Rows.Add(row);

            foreach (var rowItem in dataTable.Rows)
            {
                Console.WriteLine(rowItem[(int)Fields.Sehir].ToString());
                foreach (var column in rowItem)
                {
                    Console.WriteLine(column.ToString());
                }
            }

        }     
        
    }


    class DataTable
    {
        public List<DataRow> Rows = new List<DataRow>();
    }
    class DataRow : IEnumerable, IEnumerator
    {
        private List<Object> internalData = new List<Object>();        

        object IEnumerator.Current => this.internalData[isaret];

        public void AddValue(object value)
        {
            internalData.Add(value);
        }
        public override string ToString()
        {
            return String.Join("; ", internalData);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        int isaret = -1;
        public bool MoveNext()
        {
            if (isaret < this.internalData.Count-1)
            {
                isaret++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
           isaret = -1;
        }

        public object Current => this.internalData[isaret];
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object this[int i]
        {
            get
            {
                return internalData[i];
            }
            set
            {
                internalData[i] = value;
            }
        }
    }
}