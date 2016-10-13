﻿namespace Atata
{
    /// <summary>
    /// Indicates that the screenshot should be captured with an optional title. By default occurs before the click.
    /// </summary>
    public class ScreenshotAttribute : TriggerAttribute
    {
        public ScreenshotAttribute(string title = null, TriggerEvents on = TriggerEvents.BeforeClick, TriggerPriority priority = TriggerPriority.Medium, TriggerScope appliesTo = TriggerScope.Self)
            : base(on, priority, appliesTo)
        {
            Title = title;
        }

        public string Title { get; private set; }

        public override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            context.Log.Screenshot(Title);
        }
    }
}
