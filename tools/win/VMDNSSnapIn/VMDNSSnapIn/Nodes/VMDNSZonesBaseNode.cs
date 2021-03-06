﻿/*
 * Copyright © 2012-2016 VMware, Inc.  All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the “License”); you may not
 * use this file except in compliance with the License.  You may obtain a copy
 * of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an “AS IS” BASIS, without
 * warranties or conditions of any kind, EITHER EXPRESS OR IMPLIED.  See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using Microsoft.ManagementConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMDNS.Client;
using VMDNSSnapIn.ListViews;

namespace VMDNSSnapIn.Nodes
{
     abstract class VMDNSZonesBaseNode : VMDNSRootNode
    {
        public int ZoneType { get; set; }
        public ZoneDetailsListview ListView { get; set; }

        protected VMDNSZonesBaseNode(VMDNSServerNode node)
            : base(node)
        {
            this.DisplayName = string.Empty;
        }

        protected abstract void RefreshChildren();

        protected override void OnExpand(AsyncStatus status)
        {
            //override and do nothing
        }

        protected void AddNewZone(VMDNS_ZONE_INFO zoneInfo)
        {
            UIErrorHelper.CheckedExec(delegate()
            {
                ServerNode.ServerDTO.DNSClient.CreateZone(zoneInfo);
                this.RefreshChildren();
            });
        }
    }
}
