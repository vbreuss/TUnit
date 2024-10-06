"use strict";(self.webpackChunktunit_docs_site=self.webpackChunktunit_docs_site||[]).push([[3398],{380:(e,s,n)=>{n.r(s),n.d(s,{assets:()=>a,contentTitle:()=>c,default:()=>p,frontMatter:()=>o,metadata:()=>i,toc:()=>l});var t=n(4848),r=n(8453);const o={sidebar_position:13},c="Class Constructor Helpers",i={id:"tutorial-extras/class-constructors",title:"Class Constructor Helpers",description:"Some test suites might be more complex than others, and a user may want control over 'newing' up their test classes.",source:"@site/docs/tutorial-extras/class-constructors.md",sourceDirName:"tutorial-extras",slug:"/tutorial-extras/class-constructors",permalink:"/TUnit/docs/tutorial-extras/class-constructors",draft:!1,unlisted:!1,tags:[],version:"current",sidebarPosition:13,frontMatter:{sidebar_position:13},sidebar:"tutorialSidebar",previous:{title:"Executors",permalink:"/TUnit/docs/tutorial-extras/executors"},next:{title:"Command Line Flags",permalink:"/TUnit/docs/tutorial-extras/command-line-flags"}},a={},l=[];function d(e){const s={code:"code",h1:"h1",header:"header",p:"p",pre:"pre",...(0,r.R)(),...e.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(s.header,{children:(0,t.jsx)(s.h1,{id:"class-constructor-helpers",children:"Class Constructor Helpers"})}),"\n",(0,t.jsxs)(s.p,{children:["Some test suites might be more complex than others, and a user may want control over 'newing' up their test classes.\nThis control is given to you by the ",(0,t.jsx)(s.code,{children:"[ClassConstructorAttribute<T>]"})," - Where ",(0,t.jsx)(s.code,{children:"T"})," is a class that implements ",(0,t.jsx)(s.code,{children:"IClassConstructor"}),"."]}),"\n",(0,t.jsx)(s.p,{children:"This interface is very generic so you have freedom to construct and dispose as you please."}),"\n",(0,t.jsx)(s.p,{children:"By giving the freedom of how classes are created, we can tap into things like Dependency Injection."}),"\n",(0,t.jsx)(s.p,{children:"Here's an example of that using the Microsoft.Extensions.DependencyInjection library"}),"\n",(0,t.jsx)(s.pre,{children:(0,t.jsx)(s.code,{className:"language-csharp",children:"using TUnit.Core;\n\nnamespace MyTestProject;\n\npublic class DependencyInjectionClassConstructor : IClassConstructor\n{\n    private static readonly IServiceProvider _serviceProvider = CreateServiceProvider();\n    \n    private static readonly ConditionalWeakTable<object, IServiceScope> Scopes = new();\n\n    public T Create<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>() where T : class\n    {\n        var scope = _serviceProvider.CreateAsyncScope();\n        \n        var instance = ActivatorUtilities.GetServiceOrCreateInstance<T>(scope.ServiceProvider);\n        \n        Scopes.Add(instance, scope);\n        \n        return instance;\n    }\n\n    public async Task DisposeAsync<T>(T t)\n    {\n        if (t is IAsyncDisposable asyncDisposable)\n        {\n            await asyncDisposable.DisposeAsync();\n        }\n        else if (t is IDisposable disposable)\n        {\n            disposable.Dispose();\n        }\n        \n        if (t != null && Scopes.TryGetValue(t, out var scope))\n        {\n            if (scope is IAsyncDisposable asyncScope)\n            {\n                await asyncScope.DisposeAsync();\n            }\n            else\n            {\n                scope.Dispose();\n            }\n        }\n    }\n\n    private static IServiceProvider CreateServiceProvider()\n    {\n        return new ServiceCollection()\n            .AddSingleton<SomeClass1>()\n            .AddSingleton<SomeClass2>()\n            .AddTransient<SomeClass3>()\n            .BuildServiceProvider();\n    }\n}\n\n[ClassConstructor<DependencyInjectionClassConstructor>]\npublic class MyTestClass(SomeClass1 someClass1, SomeClass2 someClass2, SomeClass3 someClass3)\n{\n    [Test]\n    public async Task Test()\n    {\n        // ...\n    }\n}\n"})})]})}function p(e={}){const{wrapper:s}={...(0,r.R)(),...e.components};return s?(0,t.jsx)(s,{...e,children:(0,t.jsx)(d,{...e})}):d(e)}},8453:(e,s,n)=>{n.d(s,{R:()=>c,x:()=>i});var t=n(6540);const r={},o=t.createContext(r);function c(e){const s=t.useContext(o);return t.useMemo((function(){return"function"==typeof e?e(s):{...s,...e}}),[s,e])}function i(e){let s;return s=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:c(e.components),t.createElement(o.Provider,{value:s},e.children)}}}]);