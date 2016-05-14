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
            //Hado();
            //Tatsu();
            //CrouchBackward();

            ComboBlock();
            //BlockAllHits();
            //FightIA();
        }

        public void BlockAllHits()
        {
            if (ia.guardProced || ia.projGuardProced)
                if(opponent.attackState.zone == AttackZone.Low)
                    ia.buffer.moveCrouchBackward = true;
                else
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
                ia.buffer.shoryuMotion = true;
            }
        }
        public void Tatsu()
        {
            if (ia.isOnGround)
            {
                ia.buffer.tatsuMotion = true;
            }
        }
        public void Hado()
        {
            if (ia.isOnGround)
            {
                ia.buffer.hadoMotion = true;
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

        public void FightIA()
        {
            BlockAllHits();
        }
    }
}
