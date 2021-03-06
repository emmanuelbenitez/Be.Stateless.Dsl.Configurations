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

using System.IO;
using Be.Stateless.Argument.Validation;

namespace Be.Stateless.Resources
{
	public static class Files
	{
		public static Stream Load(string name)
		{
			Arguments.Validation.Constraints
				.IsNotNullOrWhiteSpace(name, nameof(name))
				.Check();

			return typeof(Files).Assembly.GetManifestResourceStream(typeof(Files), name) ??
				throw new FileNotFoundException($"The resource '{name}' is not found", name);
		}
	}
}
