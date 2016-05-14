using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fight.MoveData;

namespace Fight
{
    public static class MoveList
    {
        public static StandingJab standingJab;
        public static CloseStandingJab closeStandingJab;
        public static JumpingJab jumpingJab;
        public static NeutralJumpingJab neutralJumpingJab;
        public static CrouchingJab crouchingJab;

        public static StandingStrong standingStrong;
        public static CloseStandingStrong closeStandingStrong;
        public static JumpingStrong jumpingStrong;
        public static NeutralJumpingStrong neutralJumpingStrong;
        public static CrouchingStrong crouchingStrong;

        public static StandingFierce standingFierce;
        public static CloseStandingFierce closeStandingFierce;
        public static JumpingFierce jumpingFierce;
        public static NeutralJumpingFierce neutralJumpingFierce;
        public static CrouchingFierce crouchingFierce;

        public static StandingShort standingShort;
        public static CloseStandingShort closeStandingShort;
        public static JumpingShort jumpingShort;
        public static NeutralJumpingShort neutralJumpingShort;
        public static CrouchingShort crouchingShort;

        public static StandingForward standingForward;
        public static CloseStandingForward closeStandingForward;
        public static JumpingForward jumpingForward;
        public static NeutralJumpingForward neutralJumpingForward;
        public static CrouchingForward crouchingForward;

        public static StandingRoundhouse standingRoundhouse;
        public static CloseStandingRoundhouse closeStandingRoundhouse;
        public static JumpingRoundhouse jumpingRoundhouse;
        public static NeutralJumpingRoundhouse neutralJumpingRoundhouse;
        public static CrouchingRoundhouse crouchingRoundhouse;

        public static LightShoryu lightShoryu;
        public static MediumShoryu mediumShoryu;
        public static HardShoryu hardShoryu;

        public static LightHado lightHado;
        public static MediumHado mediumHado;
        public static HardHado hardHado;

        public static LightTatsu lightTatsu;
        public static MediumTatsu mediumTatsu;
        public static HardTatsu hardTatsu;

        public static void Load()
        {
            standingJab = new StandingJab();
            closeStandingJab = new CloseStandingJab();
            crouchingJab = new CrouchingJab();
            jumpingJab = new JumpingJab();
            neutralJumpingJab = new NeutralJumpingJab();

            standingStrong = new StandingStrong();
            closeStandingStrong = new CloseStandingStrong();
            crouchingStrong = new CrouchingStrong();
            jumpingStrong = new JumpingStrong();
            neutralJumpingStrong = new NeutralJumpingStrong();

            standingFierce = new StandingFierce();
            closeStandingFierce = new CloseStandingFierce();
            crouchingFierce = new CrouchingFierce();
            jumpingFierce = new JumpingFierce();
            neutralJumpingFierce = new NeutralJumpingFierce();

            standingShort = new StandingShort();
            closeStandingShort = new CloseStandingShort();
            crouchingShort = new CrouchingShort();
            jumpingShort = new JumpingShort();
            neutralJumpingShort = new NeutralJumpingShort();

            standingForward = new StandingForward();
            closeStandingForward = new CloseStandingForward();
            crouchingForward = new CrouchingForward();
            jumpingForward = new JumpingForward();
            neutralJumpingForward = new NeutralJumpingForward();

            standingRoundhouse = new StandingRoundhouse();
            closeStandingRoundhouse = new CloseStandingRoundhouse();
            crouchingRoundhouse = new CrouchingRoundhouse();
            jumpingRoundhouse = new JumpingRoundhouse();
            neutralJumpingRoundhouse = new NeutralJumpingRoundhouse();

            lightShoryu = new LightShoryu();
            mediumShoryu = new MediumShoryu();
            hardShoryu = new HardShoryu();

            lightTatsu = new LightTatsu();
            mediumTatsu = new MediumTatsu();
            hardTatsu = new HardTatsu();

            lightHado = new LightHado();
            mediumHado = new MediumHado();
            hardHado = new HardHado();
           
        }
    }
}
