﻿using System;

namespace Nmro.BuildingBlocks.Web.ServiceDiscovery
{
    public class ConfigurationOptions
    {
        public Uri DiscoveryAddress { get; set; }
        public string ServiceName { get; set; }

        public int Port { get; set; }
    }
}
