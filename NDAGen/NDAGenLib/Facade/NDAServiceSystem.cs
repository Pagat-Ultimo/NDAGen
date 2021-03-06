﻿using NDAGenLib.Common;
using NDAGenLib.RemoteServer;
using NDAGenLib.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace NDAGenLib.Facade
{
    public class NDAServiceSystem
    {
        public NDAServiceSystem()
        {

        }

        public static IDefinitionService GetService()
        {
           switch(NDAConfig.Type)
            {
                case "swagger":
                    return new NDASwaggerService();
                case "remoteServer":
                    return new NDARemoteServerService();
                default:
                    return new NDASwaggerService();
            }
        }
        public static IDefinitionParser GetParser()
        {
            switch (NDAConfig.Type)
            {
                case "swagger":
                    return new NDASwaggerDefinitionParser();
                case "remoteServer":
                    return new NDARemoteServerDefinitionParser();
                default:
                    return new NDASwaggerDefinitionParser();
            }
        }


    }
}
