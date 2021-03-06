﻿#region Copyright & License

// Copyright © 2012 - 2021 François Chabot & Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Xml;
using Be.Stateless.Dsl.Configuration.Specification;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Dsl.Configuration.Specifications
{
	public class AttributeSpecificationFixture
	{
		[Theory]
		[InlineData("<configuration/>")]
		[InlineData("<configuration value=''/>")]
		public void ApplySucceeds(string xmlContent)
		{
			var attributeUpdate = new AttributeSpecification {
				Name = "value",
				Value = "test"
			};
			var document = new XmlDocument();
			document.LoadXml(xmlContent);

			attributeUpdate.Execute(document.DocumentElement);

			document.SelectSingleNode("/configuration[@value='test']").Should().NotBeNull();
		}
	}
}
