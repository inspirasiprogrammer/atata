namespace Atata
{
    /// <summary>
    /// Specifies the verification of the <c>&lt;h6&gt;</c> element content.
    /// By default occurs upon the page object initialization.
    /// If no value is specified, it uses the class name as the expected value with the <see cref="TermCase.Title"/> casing applied.
    /// </summary>
    public class VerifyH6Attribute : VerifyHeadingTriggerAttribute
    {
        public VerifyH6Attribute(TermCase termCase)
            : base(termCase)
        {
        }

        public VerifyH6Attribute(TermMatch match, TermCase termCase)
            : base(match, termCase)
        {
        }

        public VerifyH6Attribute(TermMatch match, params string[] values)
            : base(match, values)
        {
        }

        public VerifyH6Attribute(params string[] values)
            : base(values)
        {
        }

        protected override void OnExecute<TOwner>(TriggerContext<TOwner> context, string[] values)
        {
            if (Index >= 0)
            {
                var headingControl = context.Component.Owner.Controls.Create<H6<TOwner>>(
                    (Index + 1).Ordinalize(),
                    new FindByIndexAttribute(Index));

                headingControl.Should.WithRetry.MatchAny(Match, values);
            }
            else
            {
                var headingControl = context.Component.Owner.Controls.Create<H6<TOwner>>(
                    Match.FormatComponentName(values),
                    new FindByContentAttribute(Match, values));

                headingControl.Should.WithRetry.Exist();
            }
        }
    }
}
