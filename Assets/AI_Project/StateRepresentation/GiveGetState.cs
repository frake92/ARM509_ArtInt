using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_CSharp
{
    public class GiveGetState : State, IOperatorHandler<GiveGetAction, GiveGetAction>
    {

        public GiveGetState()
        {
            this.Apples = 13;
            this.Pears = 46;
            this.Peaches = 59;
        }
        private int apples;

        public int Apples
        {
            get { return apples; }
            set { apples = value; }
        }

        private int pears;
        public int Pears
        {
            get { return pears; }
            set { pears = value; }
        }

        private int peaches;
        public int Peaches
        {
            get { return peaches; }
            set { peaches = value; }
        }


        public override bool IsState
        {
            get
            {
                if (Apples < 0 || Pears < 0 || Peaches < 0)
                    return false;
                return true;
            }
        }

        public override bool IsGoalState
        {
            get
            {
                if (Apples == 0 && Pears == 0 && Peaches > 0)
                    return true;
                if (Apples == 0 && Pears > 0 && Peaches == 0)
                    return true;
                if (Apples > 0 && Pears == 0 && Peaches == 0)
                    return true;
                return false;
            }
        }

        public bool ApplyOperator(GiveGetAction fruit1, GiveGetAction fruit2)
        {
            throw new NotImplementedException();
        }

        public override State DeepClone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsOperator(GiveGetAction fruit1, GiveGetAction fruit2)
        {
            Random rnd = new Random();
            if (fruit1 == fruit2)
                return false;

            switch (fruit1)
            {
                case GiveGetAction.GiveApple:
                    break;
                case GiveGetAction.GivePeach:
                    break;
                case GiveGetAction.GivePear:
                    break;
                default:
                    break;
            }

            switch (fruit2)
            {
                case GiveGetAction.GiveApple:
                    break;
                case GiveGetAction.GivePeach:
                    break;
                case GiveGetAction.GivePear:
                    break;
                default:
                    break;
            }
        }
    }
}
