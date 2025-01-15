namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class CharacterMovableSystem : SystemMainThreadFilter<CharacterMovableSystem.Filter>, ISignalOnPlayerAdded
    {

        public override void Update(Frame f, ref Filter filter)
        {
            var input = f.GetPlayerInput(filter.PlayerLink->Player);
            FPVector3 moveSpeed = new FPVector3(1, 0 ,0);
            filter.CharacterController3D->Move(f, filter.Entity, moveSpeed);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController3D;
            public PlayerLink* PlayerLink;
        }

        public void OnPlayerAdded(Frame f, PlayerRef player, bool firstTime)
        {
            var playerData = f.GetPlayerData(player);
            var playerEntity = f.Create(playerData.PlayerAvatar);
            var playerLink = new PlayerLink
            {
                Player = player
            };
            f.Add(playerEntity, playerLink);
        }
    }
}
