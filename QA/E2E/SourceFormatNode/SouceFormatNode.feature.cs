﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace EncyclopediaGalactica.SourceFormats.QA.E2E.SourceFormatNode
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SourceFormatNodeFeatureFeature : object, Xunit.IClassFixture<SourceFormatNodeFeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SouceFormatNode.feature"
#line hidden
        
        public SourceFormatNodeFeatureFeature(SourceFormatNodeFeatureFeature.FixtureData fixtureData, EncyclopediaGalactica_SourceFormats_QA_E2E_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SourceFormatNode", "Source Format Node feature", "As a data curator\nI need to be able to create structures describing data formats\n" +
                    "in this process managing SourceFormatNodes is essential\nSo, I need CRUD and othe" +
                    "r tree related functionalities available via API.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="API returns Http status code 400 when input is invalid")]
        [Xunit.TraitAttribute("FeatureTitle", "Source Format Node feature")]
        [Xunit.TraitAttribute("Description", "API returns Http status code 400 when input is invalid")]
        [Xunit.InlineDataAttribute("null", new string[0])]
        [Xunit.InlineDataAttribute("emptystring", new string[0])]
        [Xunit.InlineDataAttribute("bb", new string[0])]
        [Xunit.InlineDataAttribute("threespaces", new string[0])]
        public void APIReturnsHttpStatusCode400WhenInputIsInvalid(string name, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("API returns Http status code 400 when input is invalid", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "url"});
                table1.AddRow(new string[] {
                            "api/sourceformatnode"});
#line 8
        testRunner.Given("there is the following endpoint", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "url"});
                table2.AddRow(new string[] {
                            "add"});
#line 11
        testRunner.And("there is the operation endpoint", ((string)(null)), table2, "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name"});
                table3.AddRow(new string[] {
                            string.Format("{0}", name)});
#line 14
        testRunner.And("the following SourceFormatNode data", ((string)(null)), table3, "And ");
#line hidden
#line 17
        testRunner.When("SourceFormatNode is sent to endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
        testRunner.Then("the api returns the following http status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SourceFormatNodeFeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SourceFormatNodeFeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
