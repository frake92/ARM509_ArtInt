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
            if (!IsOperator(fruit1, fruit2))
                return false;
            GiveGetState giveGetClone = (GiveGetState)this.DeepClone();

            switch (fruit1)
            {
                case GiveGetAction.GiveApple:
                    Apples = Apples - 1;
                    break;
                case GiveGetAction.GivePear:
                    Pears = Pears - 1;
                    break;
                case GiveGetAction.GivePeach:
                    Peaches = Peaches - 1;
                    break;
                default:
                    break;
            }
            switch (fruit2)
            {
                case GiveGetAction.GiveApple:
                    Apples = Apples - 1;
                    break;
                case GiveGetAction.GivePear:
                    Pears = Pears - 1;
                    break;
                case GiveGetAction.GivePeach:
                    Peaches = Peaches - 1;
                    break;
                default:
                    break;
            }
            if (fruit1 == GiveGetAction.GiveApple && fruit2 == GiveGetAction.GivePear)
                Peaches = Peaches + 2;
            else if (fruit1 == GiveGetAction.GiveApple && fruit2 == GiveGetAction.GivePeach)
                Pears = Pears + 2;
            else if (fruit1 == GiveGetAction.GivePear && fruit2 == GiveGetAction.GivePeach)
                Apples = Apples + 2; 
            
            
            if (fruit1 == GiveGetAction.GivePear && fruit2 == GiveGetAction.GiveApple)
                Peaches = Peaches + 2;
            else if (fruit1 == GiveGetAction.GivePeach && fruit2 == GiveGetAction.GiveApple)
                Pears = Pears + 2;
            else if (fruit1 == GiveGetAction.GivePeach && fruit2 == GiveGetAction.GivePear)
                Apples = Apples + 2;


            if (IsState)
                return true;

            this.Apples = giveGetClone.Apples;
            this.Pears = giveGetClone.Pears;
            this.Peaches = giveGetClone.Peaches;
            return false;

        }

        public override State DeepClone()
        {
            GiveGetState clone = new GiveGetState();
            clone.Apples = this.Apples;
            clone.Pears = this.Pears;
            clone.Peaches= this.Peaches;
            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is GiveGetState))
                return false;

            GiveGetState other = (GiveGetState)obj;
            if (this.Apples == other.Apples && this.Pears == other.Pears && this.Peaches == other.Peaches)
                return true;
            return false;
        }

        public bool IsOperator(GiveGetAction fruit1, GiveGetAction fruit2)
        {
            if (fruit1 == fruit2)
                return false;

            int giveableQuantity = 1;
            //if the randomized number is 1 then the random fruit is Apple,
            //if it's 2 then Pear
            //if it's 3 then Peaches
            switch (fruit1)
            {
                case GiveGetAction.GiveApple:
                    if (Apples == 0) return false;
                    break;
                case GiveGetAction.GivePear:
                    if (Pears == 0) return false;
                    break;
                case GiveGetAction.GivePeach:
                    if (Peaches == 0) return false;
                    break;
                default:
                    break;
            }
            switch (fruit2)
            {
                case GiveGetAction.GiveApple:
                    if (Apples == 0) return false;
                    break;
                case GiveGetAction.GivePear:
                    if (Pears == 0) return false;
                    break;
                case GiveGetAction.GivePeach:
                    if (Peaches == 0) return false;
                    break;
                default:
                    break;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.Apples.GetHashCode() + this.Pears.GetHashCode() + this.Peaches.GetHashCode();
        }

        public override string ToString()
        {
            return $"Apples: {this.Apples}, Pears: {this.Pears}, Peaches: {this.Peaches}";
        }
    }

}
