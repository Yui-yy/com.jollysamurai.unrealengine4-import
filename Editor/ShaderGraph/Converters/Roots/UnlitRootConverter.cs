﻿using System;
using JollySamurai.UnrealEngine4.T3D;
using JollySamurai.UnrealEngine4.T3D.Material;
using JollySamurai.UnrealEngine4.T3D.Parser;
using UnityEditor.ShaderGraph;
using UnityEditor.ShaderGraph.Internal;

namespace JollySamurai.UnrealEngine4.Import.ShaderGraph.Converters.Roots
{
    public class UnlitRootConverter : GenericConverter<Material>
    {
        public override bool CanConvert(Node unrealNode)
        {
            return unrealNode is Material rootNode && rootNode.ShadingModel == ShadingModel.Unlit;
        }

        protected override AbstractMaterialNode CreateNode(ShaderGraphBuilder builder, Material unrealNode)
        {
            return new UnlitMasterNode();
        }

        public override int GetConnectionSlotId(AbstractMaterialNode from, AbstractMaterialNode to, int toSlotId, ParsedPropertyBag propertyBag)
        {
            return -1;
        }

        public override void CreateConnections(Material unrealNode, Material unrealMaterial, ShaderGraphBuilder builder)
        {
            builder.Connect(unrealNode.EmissiveColor, unrealNode.Name, UnlitMasterNode.ColorSlotId);
            builder.Connect(unrealNode.Opacity, unrealNode.Name, UnlitMasterNode.AlphaSlotId);

            if(unrealNode.Specular != null) {
                // FIXME: support specular or at least raise a warning?
                // builder.Connect(unrealNode.Specular?.NodeName, unrealNode.Name, PBRMasterNode.SpecularSlotId, unrealNode.Specular);
            }
        }
    }
}
