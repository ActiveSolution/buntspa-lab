using System;

namespace Bunt.Core.Domain.Model
{
    public class BuntladeStalle
    {
        public Guid Id { get; private set; }
        public string Adress { get; private set; }
        public int Typ { get; private set; }

        protected BuntladeStalle()
        {            
        }

        public BuntladeStalle(Guid id, string adress, int typ)
        {
            Id = id;
            Adress = adress;
            Typ = typ;
        }

        public void Redigera(string adress, int typ)
        {
            Adress = adress;
            Typ = typ;
        }
    }
}