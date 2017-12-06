using System;

namespace Bunt.Core.Domain.Model
{
    public class BuntladeStalle
    {
        public Guid Id { get; private set; }
        public string Adress { get; private set; }
        public int Typ { get; private set; }
        public int Index { get; private set; }
        public int Buntladenummer { get; private set; }

        protected BuntladeStalle()
        {
        }

        public BuntladeStalle(Guid id, string adress, int typ, int index)
        {
            Id = id;
            Adress = adress;
            Typ = typ;
            Index = index;
            Buntladenummer = 0;
        }

        public void Redigera(string adress, int typ)
        {
            Adress = adress;
            Typ = typ;
        }

        public void Omsortera(int newIndex)
        {
            Index = newIndex;
        }
    }
}