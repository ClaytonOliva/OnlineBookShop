// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace OnlineBookShop.DependencyResolution {
    using StructureMap;
	
    public static class IoC {
        public static IContainer Initialize() {
            Container container = OnlineBookShop.Bootstrapper.ApiConfig.ConfigureBindings();
            container.Configure(c =>
            {
                c.AddRegistry<DefaultRegistry>();
            });
            return container;


            //Container container = new Container();
            //container.Configure(c =>
            //{
            //    c.AddRegistry<DefaultRegistry>();
            //    c.AddRegistry<Service.DependencyResolution.ServiceRegistry>();
            //    c.AddRegistry<Data.DependencyResolution.DataRegistry>();
            //    c.For<System.Data.IDbConnection>().Use<System.Data.SqlClient.SqlConnection>().Ctor<string>().Is("YOUR_CONNECTION_STRING");
            //});
           
            //return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}