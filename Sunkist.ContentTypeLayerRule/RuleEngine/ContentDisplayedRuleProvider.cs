using System;
using Orchard.Widgets.Services;
using Sunkist.ContentTypeLayerRule.Handlers;

namespace Sunkist.ContentTypeLayerRule.RuleEngine {
    public class ContentDisplayedRuleProvider : IRuleProvider {
        private readonly IDisplayedContentItemHandler _displayedContentItemHandler;

        public ContentDisplayedRuleProvider(IDisplayedContentItemHandler displayedContentItemHandler) {
            _displayedContentItemHandler = displayedContentItemHandler;
        }

        public void Process(RuleContext ruleContext) {
            if (!String.Equals(ruleContext.FunctionName, "contenttype", StringComparison.OrdinalIgnoreCase)) {
                return;
            }

            var contentType = Convert.ToString(ruleContext.Arguments[0]);

            ruleContext.Result = _displayedContentItemHandler.IsDisplayed(contentType);
        }
    }
}