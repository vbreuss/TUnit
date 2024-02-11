using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = TUnit.Analyzers.Tests.Verifiers.CSharpAnalyzerVerifier<TUnit.Analyzers.DataSourceDrivenTestArgumentsAnalyzer>;

namespace TUnit.Analyzers.Tests;

public class DataSourceDrivenTestArgumentsAnalyzerTests
{
    [Test]
    public async Task DataSourceDriven_Argument_Is_Flagged_When_Does_Not_Match_Parameter_Type()
    {
        const string text = """
                            using TUnit.Assertions;
                            using TUnit.Core;

                            public class MyClass
                            {
                            
                                [{|#0:DataSourceDrivenTest(nameof(Data))|}]
                                public void MyTest(string value)
                                {
                                }

                                public static int Data()
                                {
                                    return 1;
                                }
                            }
                            """;

        var expected = Verifier.Diagnostic(Rules.InvalidDataSourceAssertion.Id).WithLocation(0)
            .WithArguments("int", "string");
        
        await Verifier.VerifyAnalyzerAsync(text, expected).ConfigureAwait(false);
    }
    
    [Test]
    public async Task DataDriven_Argument_Is_Not_Flagged_When_Matches_Parameter_Type()
    {
        const string text = """
                            public class MyClass
                            {
                            
                                [DataSourceDrivenTest(nameof(Data))]
                                public void MyTest(int value)
                                {
                                }
                                
                                public static int Data()
                                {
                                    return 1;
                                }
                            }
                            """;
        
        await Verifier.VerifyAnalyzerAsync(text);
    }
}