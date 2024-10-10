"use strict";(self.webpackChunktunit_docs_site=self.webpackChunktunit_docs_site||[]).push([[8887],{511:(e,t,s)=>{s.r(t),s.d(t,{assets:()=>l,contentTitle:()=>o,default:()=>u,frontMatter:()=>r,metadata:()=>a,toc:()=>c});var n=s(4848),i=s(8453);const r={sidebar_position:7},o="Extensibility / Custom Assertions",a={id:"tutorial-assertions/extensibility",title:"Extensibility / Custom Assertions",description:"The TUnit Assertions can be easily extended so that you can create your own assertions.",source:"@site/docs/tutorial-assertions/extensibility.md",sourceDirName:"tutorial-assertions",slug:"/tutorial-assertions/extensibility",permalink:"/TUnit/docs/tutorial-assertions/extensibility",draft:!1,unlisted:!1,tags:[],version:"current",sidebarPosition:7,frontMatter:{sidebar_position:7},sidebar:"tutorialSidebar",previous:{title:"Delegates",permalink:"/TUnit/docs/tutorial-assertions/delegates"},next:{title:"Congratulations",permalink:"/TUnit/docs/tutorial-assertions/congratulations"}},l={},c=[];function d(e){const t={code:"code",em:"em",h1:"h1",header:"header",li:"li",ol:"ol",p:"p",pre:"pre",ul:"ul",...(0,i.R)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)(t.header,{children:(0,n.jsx)(t.h1,{id:"extensibility--custom-assertions",children:"Extensibility / Custom Assertions"})}),"\n",(0,n.jsx)(t.p,{children:"The TUnit Assertions can be easily extended so that you can create your own assertions."}),"\n",(0,n.jsx)(t.p,{children:"In TUnit, there are two types of things we can assert on:"}),"\n",(0,n.jsxs)(t.ul,{children:["\n",(0,n.jsx)(t.li,{children:"Values"}),"\n",(0,n.jsx)(t.li,{children:"Delegates"}),"\n"]}),"\n",(0,n.jsxs)(t.p,{children:["Values is what you'd guess, some return value, such as a ",(0,n.jsx)(t.code,{children:"string"})," or ",(0,n.jsx)(t.code,{children:"int"})," or even a complex class."]}),"\n",(0,n.jsxs)(t.p,{children:["Delegates are bits of code that haven't executed yet - Instead they are passed into the assertion builder, and the TUnit assertion library will execute it. If it throws, then there will be an ",(0,n.jsx)(t.code,{children:"Exception"})," object we can check in our assertion."]}),"\n",(0,n.jsx)(t.p,{children:"So to create a custom assertion:"}),"\n",(0,n.jsxs)(t.ol,{children:["\n",(0,n.jsxs)(t.li,{children:["\n",(0,n.jsx)(t.p,{children:"There are multiple classes you can inherit from to simplify your needs:"}),"\n",(0,n.jsxs)(t.ol,{children:["\n",(0,n.jsxs)(t.li,{children:["If you want to assert a value has some expected data, then inherit from the ",(0,n.jsx)(t.code,{children:"ExpectedValueAssertCondition<TActual, TExpected>"})]}),"\n",(0,n.jsxs)(t.li,{children:["If you want to assert a value meets some criteria (e.g. IsNull) then inherit from ",(0,n.jsx)(t.code,{children:"ValueAssertCondition<TActual>"})]}),"\n",(0,n.jsxs)(t.li,{children:["If you want to assert a delegate threw or didn't throw an exception, inherit from ",(0,n.jsx)(t.code,{children:"DelegateAssertCondition"})," or ",(0,n.jsx)(t.code,{children:"ExpectedExceptionDelegateAssertCondition<TException>"})]}),"\n",(0,n.jsxs)(t.li,{children:["If those don't fit what you need, the most basic class to inherit from is ",(0,n.jsx)(t.code,{children:"BaseAssertCondition<TActual>"})]}),"\n"]}),"\n"]}),"\n",(0,n.jsxs)(t.li,{children:["\n",(0,n.jsxs)(t.p,{children:["For the generic types above, ",(0,n.jsx)(t.code,{children:"TActual"})," will be the type of object that is being asserted. For example if I started with ",(0,n.jsx)(t.code,{children:'Assert.That("Some text")'})," then ",(0,n.jsx)(t.code,{children:"TActual"})," would be a ",(0,n.jsx)(t.code,{children:"string"})," because that's what we're asserting on."]}),"\n",(0,n.jsxs)(t.p,{children:[(0,n.jsx)(t.code,{children:"TExpected"})," will be the data (if any) that you receive from your extension method, so you'll be responsible for passing this in. You must pass it to the base class via the base constructor: ",(0,n.jsx)(t.code,{children:"base(expectedValue)"})]}),"\n"]}),"\n",(0,n.jsxs)(t.li,{children:["\n",(0,n.jsxs)(t.p,{children:["Override the method:\n",(0,n.jsx)(t.code,{children:"protected override AssertionResult Passes(...)"})]}),"\n",(0,n.jsxs)(t.p,{children:[(0,n.jsx)(t.code,{children:"AssertionResult"})," has static methods to represent a pass or a fail."]}),"\n",(0,n.jsx)(t.p,{children:"You will be passed relevant objects based on what you're asserting. These may or may not be null, so the logic is up to you."}),"\n",(0,n.jsxs)(t.p,{children:["Any ",(0,n.jsx)(t.code,{children:"Exception"})," object will be populated if your assertion is a Delegate type and the delegate threw."]}),"\n",(0,n.jsxs)(t.p,{children:["Any ",(0,n.jsx)(t.code,{children:"TActual"})," object will be populated if a value was passed into ",(0,n.jsx)(t.code,{children:"Assert.That(...)"}),", or a delegate with a return value was executed successfully."]}),"\n"]}),"\n",(0,n.jsxs)(t.li,{children:["\n",(0,n.jsxs)(t.p,{children:["Override the ",(0,n.jsx)(t.code,{children:"GetExpectation"}),' method to return a message representing what would have been a success, in the format of "to [Your Expectation]".\ne.g. Expected [Actual Value] ',(0,n.jsx)(t.em,{children:"to be equal to [Expected Value]"})]}),"\n"]}),"\n"]}),"\n",(0,n.jsxs)(t.p,{children:["When you return an ",(0,n.jsx)(t.code,{children:"AssertionResult.Fail"})," result, you supply a message. This is appended after the above statement with a ",(0,n.jsx)(t.code,{children:"but {Your Message}"}),"\ne.g. Expected [Actual Value] to be equal to [Expected Value] ",(0,n.jsx)(t.em,{children:"but it was null"})]}),"\n",(0,n.jsx)(t.p,{children:"In your assertion class, that'd be set up like:"}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'    protected override string GetExpectation()\n        => $"to be equal to {Format(expected).TruncateWithEllipsis(100)}";\n\n   protected internal override AssertionResult Passes(string? actualValue, string? expectedValue)\n    {\n        if (actualValue is null)\n        {\n            return AssertionResult\n                .FailIf(\n                    () => expectedValue is not null,\n                    "it was null");\n        }\n\n        ...\n    }\n'})}),"\n",(0,n.jsxs)(t.ol,{children:["\n",(0,n.jsxs)(t.li,{children:["\n",(0,n.jsx)(t.p,{children:"Create the extension method!"}),"\n",(0,n.jsxs)(t.p,{children:["You need to create an extension off of either ",(0,n.jsx)(t.code,{children:"IValueSource<TActual>"})," or ",(0,n.jsx)(t.code,{children:"IDelegateSource<TActual>"})," - Depending on what you're planning to write an assertion for. By extending off of the relevant interface we make sure that it won't be shown where it doesn't make sense thanks to the C# typing system."]}),"\n",(0,n.jsxs)(t.p,{children:["Your return type for the extension method should be ",(0,n.jsx)(t.code,{children:"InvokableValueAssertionBuilder<TActual>"})," or ",(0,n.jsx)(t.code,{children:"InvokableDelegateAssertionBuilder<TActual>"})," depending on what type your assertion is."]}),"\n",(0,n.jsxs)(t.p,{children:["And then finally, you call ",(0,n.jsx)(t.code,{children:"source.RegisterAssertion(assertCondition, [...callerExpressions])"})," - passing in your newed up your custom assert condition class.\nThe argument expression array allows you to pass in ",(0,n.jsx)(t.code,{children:"[CallerArgumentExpression]"})," values so that your assertion errors show you the code executed to give clear exception messages."]}),"\n"]}),"\n"]}),"\n",(0,n.jsx)(t.p,{children:"Here's a fully fledged assertion in action:"}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'public static InvokableValueAssertionBuilder<string> Contains(this IValueSource<string> valueSource, string expected, StringComparison stringComparison, [CallerArgumentExpression("expected")] string doNotPopulateThisValue1 = "", [CallerArgumentExpression("stringComparison")] string doNotPopulateThisValue2 = "")\n    {\n        return valueSource.RegisterAssertion(\n            assertCondition: new StringEqualsAssertCondition(expected, stringComparison),\n            argumentExpressions: [doNotPopulateThisValue1, doNotPopulateThisValue2]\n            );\n    }\n'})}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'public class StringEqualsExpectedValueAssertCondition(string expected, StringComparison stringComparison)\n    : ExpectedValueAssertCondition<string, string>(expected)\n{\n    protected override string GetExpectation()\n        => $"to be equal to {Format(expected).TruncateWithEllipsis(100)}";\n\n    protected internal override AssertionResult Passes(string? actualValue, string? expectedValue)\n    {\n        if (actualValue is null)\n        {\n            return AssertionResult\n                .FailIf(\n                    () => expectedValue is not null,\n                    "it was null");\n        }\n\n        return AssertionResult\n            .FailIf(\n                () => !string.Equals(actualValue, expectedValue, stringComparison),\n                $"found {Format(actualValue).TruncateWithEllipsis(100)}");\n    }\n}\n'})})]})}function u(e={}){const{wrapper:t}={...(0,i.R)(),...e.components};return t?(0,n.jsx)(t,{...e,children:(0,n.jsx)(d,{...e})}):d(e)}},8453:(e,t,s)=>{s.d(t,{R:()=>o,x:()=>a});var n=s(6540);const i={},r=n.createContext(i);function o(e){const t=n.useContext(r);return n.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:o(e.components),n.createElement(r.Provider,{value:t},e.children)}}}]);