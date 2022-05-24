using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }

        private int _ID;
        private States _State;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
