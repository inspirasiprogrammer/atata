﻿namespace Atata
{
    /// <summary>
    /// Defines the keys to press on the specified event. By default occurs after the set.
    /// </summary>
    public class PressKeysAttribute : TriggerAttribute
    {
        public PressKeysAttribute(string keys, TriggerEvents on = TriggerEvents.AfterSet, TriggerPriority priority = TriggerPriority.Medium, TriggerScope appliesTo = TriggerScope.Self)
            : base(on, priority, appliesTo)
        {
            Keys = keys;
        }

        public string Keys { get; protected set; }

        public override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            if (!string.IsNullOrEmpty(Keys))
            {
                context.Driver.Perform(x => x.SendKeys(Keys));
            }
        }
    }
}
