﻿namespace RainMeadow
{
    public abstract class EntityState : OnlineState // Is this class completely redundant? everything inherits from PhysicalObjectEntityState
    {
        public OnlineEntity onlineEntity;
        public bool realizedState;

        protected EntityState() : base() { }
        protected EntityState(OnlineEntity onlineEntity, ulong ts, bool realizedState) : base(ts)
        {
            if(onlineEntity == null) { throw new System.Exception("here you dumbass"); }
            this.onlineEntity = onlineEntity;
            this.realizedState = realizedState;
        }

        public override void CustomSerialize(Serializer serializer)
        {
            base.CustomSerialize(serializer);
            serializer.SerializeEntity(ref onlineEntity);
            serializer.Serialize(ref realizedState);
        }

        public abstract void ReadTo(OnlineEntity onlineEntity);
    }
}
