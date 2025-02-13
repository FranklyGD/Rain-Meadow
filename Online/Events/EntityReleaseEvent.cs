﻿namespace RainMeadow
{
    public class EntityReleaseEvent : EntityEvent, ResolvableEvent
    {
        public OnlineResource inResource;

        public EntityReleaseEvent() { }

        public EntityReleaseEvent(OnlineEntity oe, OnlineResource inResource) : base(oe)
        {
            this.inResource = inResource;
        }

        public override void CustomSerialize(Serializer serializer)
        {
            base.CustomSerialize(serializer);
            serializer.Serialize(ref inResource);
        }

        public override EventTypeId eventType => EventTypeId.EntityRelease;

        public override void Process()
        {
            oe.Released(this);
        }

        public void Resolve(GenericResult genericResult)
        {
            this.oe.ResolveRelease(genericResult);
        }
    }
}