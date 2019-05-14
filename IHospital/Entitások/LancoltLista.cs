using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHospital.Entitások
{
    sealed class LancoltLista
    {
        private ListElement head;

        class ListElement
        {
            public Beteg data;
            public ListElement next;

            public ListElement(Beteg data)
            {
                this.data = data;
            }
        }


        public void Add(Beteg data)
        {
            ListElement newElem = new ListElement(data);
            ListElement temp = head;
            ListElement temp2 = null;
            while((temp != null) &&(temp.data.Diagnózis.Súlyosság >= data.Diagnózis.Súlyosság))
            {
                temp2 = temp;
                temp = temp.next;
            }
            if(temp2 == null)
            {
                newElem.next = head;
                head = newElem;
            }
            else
            {
                newElem.next = temp;
                temp2.next = newElem;
            }
        }

        public void Remove(Beteg data)
        {
            ListElement temp = head;
            ListElement temp2 = null;
            while((temp != null) && (temp.data != data))
            {
                temp2 = temp;
                temp = temp.next;
            }
            if (temp != null)
            {
                if (temp2 == null)
                {
                    head = temp.next;
                }
                else
                {
                    temp2.next = temp.next;
                }
            }
            else
            {
                throw new NincsIlyenBetegKivétel("A beteget nem lehet műteni, mert nem létezik!");
            }
        }

        public int Size()
        {
            ListElement elem = head;
            int size = 0;
            while (elem != null)
            {
                size++;
                elem = elem.next;
            }
            return size;
        }

        public Beteg Get(int idx)
        {
            ListElement elem = head;
            int i = 0;
            while (i != idx)
            {
                if (elem != null)
                {
                    elem = elem.next;
                    i++;
                }
                else
                {
                    return null;
                }
            }
            return elem.data;
        }

        public Beteg Find(string név)
        {
            ListElement elem = head;
            bool found = false;
            while(elem!=null && !found)
            {
                found = elem.data.Név.Equals(név);
                if (!found) elem = elem.next;
            }
            return elem!=null ? elem.data : null;
        }

        public void WriteElems()
        {
            ListElement elem = head;
            while(elem != null)
            {
                elem.data.Kiír();
                elem = elem.next;
            }
        }

    }
}
