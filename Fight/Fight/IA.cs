using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fight
{
    public class IA
    {
        Fighter ia;
        Fighter opponent;
        float timer=100;
        public bool blockall = false;

        public IA(Fighter ia, Fighter opponent)
        {
            this.ia = ia;
            this.opponent = opponent;
        }

        public void Update()
        {
            blockall = false;
            //Shoryu();
            //CrouchBackward();
            ComboBlock();
            //BlockAllHits();
        }

        public void BlockAllHits()
        {
            ia.guardProced = true;
            ia.buffer.moveBackward = true;
        }

        public void MoveBackward()
        {
            ia.buffer.moveBackward = true;
        }

        public void CrouchBackward()
        {
            ia.buffer.moveCrouchBackward = true;
        }
        public void MoveForward()
        {
            ia.buffer.moveForward = true;
        }

        public void Jab()
        {
            ia.state = State.Attack;
            ia.attackState.type = AttackType.Jab;
        }
        public void Short()
        {
            ia.state = State.Attack;
            ia.attackState.type = AttackType.Short;
        }
        public void Shoryu()
        {
            if (ia.isOnGround)
            {
                ia.state = State.Attack;
                ia.attackState.type = AttackType.Dragon;
            }
        }

        public void ComboBlock()
        {
            timer++;
            
            if (timer < 40)
            {
                BlockAllHits();
            }
            else
            {
                ia.guardProced = false;
                ia.blockStuned = false;
            }

            if (ia.wasHit || ia.blocked)
            {
                timer = 0;
            }

            
        }
    }
}
