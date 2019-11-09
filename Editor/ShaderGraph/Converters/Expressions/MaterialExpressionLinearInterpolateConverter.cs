﻿using System;
using JollySamurai.UnrealEngine4.T3D;
using JollySamurai.UnrealEngine4.T3D.Material;
using UnityEditor.ShaderGraph;
using UnityEditor.ShaderGraph.Internal;

namespace JollySamurai.UnrealEngine4.Import.ShaderGraph.Converters.Expressions
{
    public class MaterialExpressionLinearInterpolateConverter : GenericConverter<MaterialExpressionLinearInterpolate>
    {
        public override bool CanConvert(Node unrealNode)
        {
            return unrealNode is MaterialExpressionLinearInterpolate;
        }

        protected override AbstractMaterialNode CreateNode(ShaderGraphBuilder builder, MaterialExpressionLinearInterpolate unrealNode)
        {
            return new LerpNode {
                previewExpanded = false,
            };
        }
    }
}
