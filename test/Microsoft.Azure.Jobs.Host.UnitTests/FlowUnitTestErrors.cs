﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Jobs.Host.UnitTests
{
    // Test failure cases for indexing
    public class FlowUnitTestErrors
    {
        [Fact]
        public void TestFails()
        {
            foreach (var method in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Assert.Throws<IndexException>(() => Indexer.GetFunctionDefinitionTest(method, new IndexTypeContext { Config = new TestConfiguration() }));
            }
        }

        private static void BadTableName([Table(@"#")] IDictionary<Tuple<string, string>, object> t) { }

        private static void MultipleQueueParams([QueueTrigger("p123")] int p123, [QueueTrigger("p234")] int p234) { }
    }
}